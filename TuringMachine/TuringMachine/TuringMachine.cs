using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Threading;

namespace TuringMachine
{
    public class TuringMachine
    {
        public List<MachineState> Q;
        public List<String> EntryAlphabet;
        public List<String> TapeAlphabet;
        public String blank { get; set; }
        public String transitionFilePath;
        public Tape MachineTape = new Tape();
        public List<int> AcceptingStates;
        bool success = false;

        // Input
        public String Entry;
        public int Pointer;

        public int CurrentStateNumber;
        public MachineState CurrentState;
        public String CurrentSymbol;

        /// <summary>
        /// Path of file containing transition states info.
        /// </summary>
        /// <param name="filePath"></param>
        public TuringMachine(String filePath, String entry)
        {
            AcceptingStates = new List<int>();
            Q = new List<MachineState>();
            EntryAlphabet = new List<string>();
            TapeAlphabet = new List<string>();
            blank = "♭";
            TapeAlphabet.Add(blank);
            Entry = entry;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public void BuildMachine(String filePath)
        {
            int CurrentStateNumber = -1;
            String[] Lines = File.ReadAllLines(filePath);
            // Creates machine states, without transitions
            for (int i = 0; i < Lines.Length; i++)
            {
                String[] CurrentState = Lines[i].Split('\t'); ;
                if (int.Parse(CurrentState[0]) != CurrentStateNumber)
                {
                    MachineState m = new MachineState();
                    Q.Add(m);
                    CurrentStateNumber = int.Parse(CurrentState[0]);
                }
            }

            // Creates machine states, with its transitions
            for (int i = 0; i < Lines.Length; i++)
            {
                String[] CurrentTransition = Lines[i].Split('\t');
                int StateNumber = int.Parse(CurrentTransition[0]);
                string Symbol = CurrentTransition[1]=="blank"?blank:CurrentTransition[1];
                int NextState = int.Parse(CurrentTransition[2]);
                string ReplacingSymbol = CurrentTransition[3] == "blank" ? blank : CurrentTransition[3];
                bool moveRight = CurrentTransition[4] == "R" ? true : false;
                Transition t = new Transition(Symbol, NextState, ReplacingSymbol, moveRight);
                Q[StateNumber].AddTransition(t);
            }

            // Fills the machine tape
            for(int i = 0; i < Entry.Length; i++)
            {
                MachineTape.AddSymbol(Entry[i].ToString());
            }

            // Gets Ready vor Everythin :u
            CurrentState = Q[CurrentStateNumber];
            try
            {
                CurrentSymbol = MachineTape.boxes[Pointer];
            }
            catch
            {
                return;
            }
        }
        
        public void Run()
        {
            do
            {
                CurrentState = Q[CurrentStateNumber];
                CurrentSymbol = MachineTape.boxes[Pointer];
                Transition t = getAdequateTransition(CurrentStateNumber, CurrentSymbol);
                if (t == null)
                {
                    Console.WriteLine("La cadena ingresada no tiene un formato válido");
                    return;
                }
                Thread.Sleep(1);
                Console.WriteLine(MachineTape);
                if (ExecuteTransition(t))
                {
                    Console.WriteLine(MachineTape);
                    return;
                }
            } while (true);
        }

        public void Next()
        {
            Transition t = getAdequateTransition(CurrentStateNumber, CurrentSymbol);
            if (t == null)
            {
                Console.WriteLine("La cadena ingresada no tiene un formato válido");
                return;
            }
            ExecuteTransition(t);
            CurrentState = Q[CurrentStateNumber];
            try
            {
                CurrentSymbol = MachineTape.boxes[Pointer];
            }
            catch
            {
                return;
            }
        }


        public bool ExecuteTransition(Transition t) {
            CurrentStateNumber = t.nextState;
            if (AcceptingStates.Contains(CurrentStateNumber))
            {
                Console.WriteLine("Finished!");
                return true;
            }
            MachineTape.boxes[Pointer] = t.replacingSymbol;
            Pointer = t.right ? Pointer + 1 : Pointer - 1;
            return false;
        }


        public Transition getAdequateTransition(int stateNumber, String symbol)
        {
            for(int i = 0; i < Q.Count; i++)
            {
                if(i == stateNumber)
                {
                    for (int j = 0; j < Q[i].Transitions.Count; j++)
                    {
                        if(Q[i].Transitions[j].symbol == symbol)
                        {
                            return Q[i].Transitions[j];
                        }
                    }
                }                
            };
            return null;
        }
    }
}
