using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Advent_Of_Code
{
    class HandheldHalting
    {
        int accumulator;
        string[] instructions;
        List<int> history;
        bool tool;

        public HandheldHalting()
        {
            instructions = input.Split("\n");
            accumulator = 0;
            history = new List<int>();
        }

        private string SwapInstruction(string ins)
        {
            if (ins.Trim().StartsWith('j'))
            {
                ins = ins.Replace("jmp", "nop");
            }
            else if (ins.Trim().StartsWith('n'))
            {
                ins = ins.Replace("nop", "jmp");
            }
            return ins;
        }

        public int ExecuteToBoot()
        {
            accumulator = 0;

            for (int i = 0; i < instructions.Length; i++)
            {
                accumulator = 0;
                tool = false;
                history = new List<int>();
                string[] modifiedInstructions = instructions;
                modifiedInstructions[i] = SwapInstruction(modifiedInstructions[i]);
                ExecuteProgramToHalt();
                if (tool)
                {
                    Console.WriteLine("Puzzle 2 Solved! Accumulator: " + accumulator + " At i: " + i);
                    return accumulator;
                }
            }
            return 0;
        }

        public int ExecuteProgramToHalt()
        {
            int pointer = 0;
            //tool = true;
            bool[] visits = new bool[instructions.Length];
            while (pointer < instructions.Length)
            {
                history.Add(accumulator);
                if (visits[pointer])
                {
                    tool = false;
                    return accumulator;
                }
                else
                {
                    visits[pointer] = true;
                }
                string[] splitInstruction = SplitInstruction(instructions[pointer]);
                switch (splitInstruction[0])
                {
                    case "acc":
                        accumulator += Int32.Parse(splitInstruction[1]);
                        pointer++;
                        break;
                    case "jmp":
                        pointer += Int32.Parse(splitInstruction[1]);
                        break;
                    case "nop":
                        pointer++;
                        break;
                }
            }
            tool = true;
            return accumulator;
        }


        public string[] SplitInstruction(string toSplit)
        {
            toSplit = toSplit.Replace('\r', ' ').Trim();
            string[] split = toSplit.Split(" ");
            return split;
        }


        string iinput = @"nop +0
                            acc +1
                            jmp +4
                            acc +3
                            jmp -3
                            acc -99
                            acc +1
                            jmp -4
                            acc +6";

        string input = @"acc +13
                        acc -6
                        acc -8
                        jmp +140
                        acc +44
                        acc +21
                        nop +23
                        jmp +455
                        acc -1
                        jmp +143
                        acc +9
                        acc +19
                        jmp +507
                        nop +513
                        acc +38
                        nop +444
                        jmp +560
                        nop +19
                        acc +9
                        acc +19
                        jmp +33
                        acc +11
                        acc -11
                        acc +10
                        jmp +486
                        nop -12
                        acc +38
                        acc +5
                        jmp +394
                        acc +23
                        jmp +236
                        acc -9
                        acc -10
                        acc +32
                        nop +45
                        jmp +562
                        jmp +423
                        acc +3
                        nop +340
                        jmp +217
                        acc -14
                        acc -6
                        jmp +397
                        acc +17
                        nop +165
                        acc +41
                        acc -9
                        jmp +554
                        nop +7
                        acc +0
                        jmp +235
                        acc +32
                        jmp +486
                        jmp +280
                        jmp +408
                        jmp +73
                        jmp +482
                        acc -17
                        acc +24
                        jmp +377
                        jmp +379
                        acc +13
                        jmp +277
                        nop +232
                        acc +2
                        acc +33
                        jmp +247
                        acc +48
                        acc +22
                        jmp +105
                        jmp +269
                        jmp +326
                        jmp +516
                        acc +32
                        nop +147
                        jmp -27
                        jmp +1
                        acc -8
                        jmp +376
                        acc -13
                        acc +0
                        acc +43
                        nop +380
                        jmp +230
                        acc +34
                        jmp +130
                        acc +18
                        acc +0
                        jmp +402
                        acc +31
                        acc -1
                        acc -5
                        jmp +134
                        jmp +334
                        acc +35
                        acc +0
                        acc +5
                        acc -10
                        jmp -85
                        acc +5
                        nop +444
                        acc +10
                        jmp -9
                        acc +46
                        acc -12
                        nop +98
                        acc +29
                        jmp +119
                        acc +8
                        acc +21
                        jmp +422
                        acc +19
                        jmp +78
                        acc +42
                        acc +18
                        nop +344
                        nop +353
                        jmp +26
                        acc -16
                        acc +20
                        jmp +370
                        acc -5
                        acc +29
                        jmp +465
                        nop +176
                        acc -13
                        acc -16
                        jmp +300
                        acc +12
                        acc +43
                        acc -1
                        jmp +215
                        nop +214
                        acc +13
                        jmp +141
                        acc -3
                        acc +42
                        acc +5
                        jmp +49
                        acc +7
                        acc +7
                        nop +2
                        jmp +5
                        nop +123
                        nop +112
                        jmp +45
                        jmp +276
                        acc +4
                        acc +5
                        acc +13
                        jmp -97
                        jmp +311
                        nop +347
                        acc +6
                        jmp +1
                        jmp +162
                        acc +36
                        acc -6
                        jmp +386
                        acc -10
                        acc -8
                        jmp +163
                        acc +32
                        acc +13
                        jmp +1
                        jmp +361
                        acc +43
                        acc +6
                        acc +31
                        jmp +52
                        acc +23
                        acc +34
                        nop +186
                        jmp +268
                        nop -103
                        acc -17
                        jmp +242
                        acc +30
                        acc -4
                        jmp -32
                        acc +27
                        acc -17
                        jmp -142
                        acc +30
                        acc +17
                        jmp +1
                        jmp +415
                        jmp -132
                        acc +15
                        jmp +176
                        acc +15
                        acc +12
                        nop +382
                        jmp +237
                        jmp +32
                        acc -8
                        acc +40
                        acc +28
                        jmp +1
                        jmp -186
                        acc +9
                        acc +49
                        jmp -55
                        acc -16
                        acc -7
                        nop +240
                        acc +29
                        jmp +255
                        jmp +182
                        acc -16
                        acc +9
                        jmp -31
                        acc -13
                        acc +29
                        jmp +387
                        acc -13
                        nop -180
                        acc -11
                        jmp +77
                        acc +16
                        jmp +368
                        jmp +224
                        acc +32
                        nop -187
                        acc +48
                        jmp +307
                        acc +11
                        acc +38
                        nop +47
                        jmp -94
                        jmp +1
                        nop -170
                        acc +31
                        jmp -180
                        acc +30
                        acc +1
                        jmp +1
                        nop -63
                        jmp -12
                        acc -4
                        acc -12
                        acc +15
                        nop -68
                        jmp +13
                        acc +24
                        nop -50
                        acc +31
                        acc -2
                        jmp +333
                        acc +39
                        nop -179
                        jmp +158
                        acc +24
                        jmp +169
                        acc -3
                        jmp -207
                        acc -13
                        jmp -54
                        acc +31
                        jmp -93
                        acc -4
                        acc +40
                        jmp -96
                        acc -15
                        acc +31
                        jmp +68
                        acc +38
                        acc +7
                        acc +12
                        jmp -9
                        acc +49
                        acc +33
                        acc +27
                        acc +36
                        jmp +50
                        jmp +208
                        jmp +1
                        acc +42
                        acc +34
                        jmp -151
                        acc +17
                        jmp -195
                        acc +37
                        acc +34
                        jmp +62
                        jmp +1
                        acc +9
                        acc +3
                        acc -2
                        jmp +266
                        nop +254
                        nop -170
                        nop -133
                        acc +40
                        jmp +225
                        acc +38
                        acc +33
                        acc +39
                        jmp +262
                        jmp -278
                        acc -17
                        acc +16
                        nop +128
                        jmp -116
                        acc +13
                        acc +49
                        acc +36
                        acc +33
                        jmp -215
                        nop -301
                        jmp -197
                        acc +50
                        jmp -37
                        acc +42
                        nop -253
                        jmp +159
                        jmp -142
                        acc +14
                        jmp -123
                        acc -7
                        acc -13
                        acc +33
                        acc +42
                        jmp +232
                        acc +2
                        acc +26
                        acc +3
                        jmp -112
                        acc +29
                        acc -12
                        nop -263
                        nop +114
                        jmp +7
                        jmp +157
                        acc -7
                        acc +11
                        nop +245
                        acc -2
                        jmp -225
                        nop +120
                        jmp -114
                        acc -5
                        acc +22
                        nop -122
                        acc -11
                        jmp -70
                        acc +1
                        acc +24
                        acc +23
                        acc +37
                        jmp +188
                        acc +0
                        acc -10
                        jmp +1
                        jmp -283
                        jmp -80
                        acc +4
                        jmp -183
                        acc -16
                        nop -306
                        jmp -213
                        acc +10
                        acc -2
                        nop -17
                        jmp +146
                        acc -8
                        acc +5
                        acc +19
                        acc +37
                        jmp -261
                        acc +28
                        acc +49
                        jmp +111
                        acc +37
                        acc +44
                        acc +20
                        jmp -11
                        jmp -53
                        acc +25
                        jmp -343
                        acc +7
                        acc +46
                        jmp -187
                        acc +20
                        acc +50
                        acc -8
                        jmp -365
                        nop -9
                        acc -18
                        jmp -43
                        nop +165
                        nop +78
                        acc +33
                        acc +19
                        jmp -321
                        acc +46
                        jmp -275
                        nop -88
                        acc +4
                        acc +33
                        acc +47
                        jmp -18
                        jmp +166
                        jmp +1
                        acc -4
                        acc -9
                        acc -2
                        jmp -173
                        jmp +54
                        acc -3
                        acc +2
                        nop +16
                        acc -13
                        jmp +184
                        acc +26
                        nop -322
                        acc -12
                        jmp -362
                        jmp -118
                        acc +7
                        acc +33
                        jmp +153
                        jmp -13
                        acc +19
                        jmp +1
                        acc +23
                        jmp -373
                        acc +12
                        jmp -184
                        jmp -185
                        jmp -57
                        acc +48
                        acc +8
                        nop +71
                        acc +26
                        jmp -96
                        jmp -227
                        acc -10
                        jmp -381
                        jmp +75
                        jmp +74
                        jmp -320
                        acc +0
                        nop +101
                        jmp -98
                        acc +33
                        acc -4
                        jmp +1
                        acc -9
                        jmp -197
                        acc +36
                        acc +15
                        acc +24
                        jmp -400
                        acc +18
                        jmp -77
                        acc +25
                        acc +1
                        jmp -112
                        nop -150
                        jmp -381
                        jmp -152
                        acc +38
                        acc +50
                        acc +43
                        jmp +103
                        nop -4
                        acc -6
                        jmp -309
                        acc +34
                        acc +2
                        acc -15
                        jmp -411
                        jmp -70
                        acc +39
                        acc -3
                        acc +6
                        acc +22
                        jmp -123
                        jmp -89
                        acc +11
                        jmp +70
                        jmp -339
                        acc -4
                        jmp -325
                        acc +44
                        acc +8
                        acc +15
                        acc +29
                        jmp +87
                        jmp -411
                        acc +30
                        jmp +12
                        acc -14
                        jmp -14
                        acc -17
                        jmp +1
                        acc -12
                        jmp -441
                        jmp +1
                        acc +0
                        acc -12
                        jmp +108
                        jmp -277
                        jmp +103
                        acc +12
                        nop -427
                        acc +10
                        acc -16
                        jmp -322
                        acc +1
                        jmp -412
                        acc +37
                        jmp -130
                        nop -474
                        jmp +86
                        acc +5
                        acc -12
                        jmp -461
                        acc -18
                        acc -12
                        acc +30
                        nop -356
                        jmp -30
                        nop -207
                        jmp -128
                        nop -168
                        acc -4
                        jmp -98
                        acc +32
                        nop -264
                        jmp -5
                        nop -337
                        acc -10
                        nop -195
                        nop +62
                        jmp -37
                        jmp -489
                        jmp -148
                        acc +50
                        acc +33
                        acc +8
                        acc +49
                        jmp -353
                        acc +1
                        nop -13
                        acc +27
                        jmp -492
                        jmp +1
                        acc +43
                        jmp -46
                        acc -16
                        jmp -149
                        acc +28
                        jmp -525
                        acc +48
                        jmp -30
                        acc -5
                        acc +21
                        jmp -15
                        jmp +1
                        acc +17
                        acc +42
                        acc +36
                        jmp -343
                        acc -7
                        acc +3
                        jmp -346
                        acc +44
                        acc +18
                        acc -10
                        nop -262
                        jmp -338
                        jmp -111
                        jmp -105
                        jmp -319
                        acc -11
                        jmp -297
                        acc +1
                        acc -3
                        jmp -271
                        acc +15
                        acc +6
                        acc +24
                        jmp -80
                        nop -477
                        acc +39
                        jmp -49
                        nop -62
                        acc +23
                        acc +15
                        jmp -47
                        acc +16
                        acc +5
                        acc +11
                        acc +42
                        jmp -430
                        acc +14
                        acc -16
                        jmp -80
                        jmp -571
                        acc +46
                        acc +31
                        jmp +1
                        acc +31
                        jmp +13
                        jmp -5
                        jmp -599
                        acc +41
                        jmp -105
                        jmp +1
                        jmp +1
                        nop -360
                        jmp -542
                        acc -5
                        acc +20
                        nop -595
                        jmp -124
                        acc +14
                        acc +40
                        acc +14
                        acc +34
                        jmp +1";

    }
}
 /***
 *
 *
 *
 *
 --- Day 8: Handheld Halting ---

Your flight to the major airline hub reaches cruising altitude without incident. While you consider checking the in-flight menu for one of those drinks that come with a little umbrella, you are interrupted by the kid sitting next to you.

Their handheld game console won't turn on! They ask if you can take a look.

You narrow the problem down to a strange infinite loop in the boot code (your puzzle input) of the device. You should be able to fix it, but first you need to be able to run the code in isolation.

The boot code is represented as a text file with one instruction per line of text. Each instruction consists of an operation (acc, jmp, or nop) and an argument (a signed number like +4 or -20).

    acc increases or decreases a single global value called the accumulator by the value given in the argument. For example, acc +7 would increase the accumulator by 7. The accumulator starts at 0. After an acc instruction, the instruction immediately below it is executed next.
    jmp jumps to a new instruction relative to itself. The next instruction to execute is found using the argument as an offset from the jmp instruction; for example, jmp +2 would skip the next instruction, jmp +1 would continue to the instruction immediately below it, and jmp -20 would cause the instruction 20 lines above to be executed next.
    nop stands for No OPeration - it does nothing. The instruction immediately below it is executed next.

For example, consider the following program:

nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6

These instructions are visited in this order:

nop +0  | 1
acc +1  | 2, 8(!)
jmp +4  | 3
acc +3  | 6
jmp -3  | 7
acc -99 |
acc +1  | 4
jmp -4  | 5
acc +6  |

First, the nop +0 does nothing. Then, the accumulator is increased from 0 to 1 (acc +1) and jmp +4 sets the next instruction to the other acc +1 near the bottom. After it increases the accumulator from 1 to 2, jmp -4 executes, setting the next instruction to the only acc +3. It sets the accumulator to 5, and jmp -3 causes the program to continue back at the first acc +1.

This is an infinite loop: with this sequence of jumps, the program will run forever. The moment the program tries to run any instruction a second time, you know it will never terminate.

Immediately before the program would run an instruction a second time, the value in the accumulator is 5.

Run your copy of the boot code. Immediately before any instruction is executed a second time, what value is in the accumulator?

Your puzzle answer was 1331.
--- Part Two ---

After some careful analysis, you believe that exactly one instruction is corrupted.

Somewhere in the program, either a jmp is supposed to be a nop, or a nop is supposed to be a jmp. (No acc instructions were harmed in the corruption of this boot code.)

The program is supposed to terminate by attempting to execute an instruction immediately after the last instruction in the file. By changing exactly one jmp or nop, you can repair the boot code and make it terminate correctly.

For example, consider the same program from above:

nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6

If you change the first instruction from nop +0 to jmp +0, it would create a single-instruction infinite loop, never leaving that instruction. If you change almost any of the jmp instructions, the program will still eventually find another jmp instruction and loop forever.

However, if you change the second-to-last instruction (from jmp -4 to nop -4), the program terminates! The instructions are visited in this order:

nop +0  | 1
acc +1  | 2
jmp +4  | 3
acc +3  |
jmp -3  |
acc -99 |
acc +1  | 4
nop -4  | 5
acc +6  | 6

After the last instruction (acc +6), the program terminates by attempting to run the instruction below the last instruction in the file. With this change, after the program terminates, the accumulator contains the value 8 (acc +1, acc +1, acc +6).

Fix the program so that it terminates normally by changing exactly one jmp (to nop) or nop (to jmp). What is the value of the accumulator after the program terminates?

Your puzzle answer was 1121.

Both parts of this puzzle are complete! They provide two gold stars: ** 
 */