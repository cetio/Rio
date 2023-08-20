using Rio.Core.Data;
using Rio.Emit;

namespace Rio.Core
{
    internal static class Engine
    {
        internal static int RIP;
        internal static Stack<Exception> Exceptions;
        internal static Flags Flags;

        static Engine()
        {
            Exceptions = new Stack<Exception>();
            Flags = Flags.none;
        }

        public static object? Invoke(Instruction[] instructions, object?[] parameters)
        {
            RIP = 0;
            Registrar.Reset();

            foreach (object? parameter in parameters)
                Registrar.Next().Value = parameter;

            while (RIP < instructions.Length)
            {
                Instruction instruction = instructions[RIP++];
                Decor decor = instruction.Decor;

                if ((decor.HasFlag(Decor.eq) && Equals(Registrar.Find(Emit.Register.RCX).Value, 1)) ||
                    (decor.HasFlag(Decor.neq) && !Equals(Registrar.Find(Emit.Register.RCX).Value, 1)) ||
                    (decor.HasFlag(Decor.deq) && !Equals(instruction.NativeOperands[^2], instruction.NativeOperands[^1])) ||
                    (decor.HasFlag(Decor.dneq) && Equals(instruction.NativeOperands[^2], instruction.NativeOperands[^1])) ||
                    (decor.HasFlag(Decor.dgt) && !(instruction.NativeOperands[^2].Unbox() > instruction.NativeOperands[^1].Unbox())) ||
                    (decor.HasFlag(Decor.dgeq) && !(instruction.NativeOperands[^2].Unbox() >= instruction.NativeOperands[^1].Unbox())) ||
                    (decor.HasFlag(Decor.dlt) && !(instruction.NativeOperands[^2].Unbox() < instruction.NativeOperands[^1].Unbox())) ||
                    (decor.HasFlag(Decor.dleq) && !(instruction.NativeOperands[^2].Unbox() <= instruction.NativeOperands[^1].Unbox())) ||
                    (decor.HasFlag(Decor.ex) && Exceptions.Count == 0) ||
                    (decor.HasFlag(Decor.nex) && Exceptions.Count != 0))
                {
                    continue;
                }

                try
                {
                    if (instruction is IOpCode opcode)
                    {
                        if (decor.HasFlag(Decor.rp) && opcode.ClusterBehavior == ClusterBehavior.Cycle)
                        {
                            for (int i = 2; i < 26; i++)
                            {
                                instruction.NativeOperands[0].Value = Registrar.Find((Emit.Register)i);
                                opcode.Run();
                            }
                        }
                        else if (decor.HasFlag(Decor.cr) && opcode.ClusterBehavior == ClusterBehavior.Cycle)
                        {
                            for (int i = 26; i < 38; i++)
                            {
                                instruction.NativeOperands[0].Value = Registrar.Find((Emit.Register)i);
                                opcode.Run();
                            }
                        }
                        else if (decor.HasFlag(Decor.a) && opcode.ClusterBehavior == ClusterBehavior.Cycle)
                        {
                            for (int i = 2; i < 38; i++)
                            {
                                instruction.NativeOperands[0].Value = Registrar.Find((Emit.Register)i);
                                opcode.Run();
                            }
                        }
                        else
                        {
                            opcode.Run();
                        }

                        if (opcode.FlowControl is FlowControl.Return)
                        {
                            return Registrar.Find(Emit.Register.RSX).Value;
                        }
                        else if (opcode.FlowControl is FlowControl.Halt)
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if ((Flags.HasFlag(Flags.atmpt) || decor.HasFlag(Flags.atmpt)) && !Flags.HasFlag(Flags.bnc) && !decor.HasFlag(Flags.bnc))
                    {
                        Exceptions.Push(ex);
                    }
                    if (!(Flags.HasFlag(Flags.bnc) || decor.HasFlag(Flags.bnc)))
                    {
                        throw;
                    }
                }
                finally
                {
                    if (Flags.HasFlag(Flags.cozy) || decor.HasFlag(Flags.cozy))
                    {
                        Thread.Sleep(1);
                    }
                }
            }

            return null;
        }
    }
}