using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DES
{
    public class DESalg
    {
        public List<int[]> sBlock1 = new List<int[]>();
        public List<int[]> sBlock2 = new List<int[]>();
        public List<int[]> sBlock3 = new List<int[]>();
        public List<int[]> sBlock4 = new List<int[]>();
        public List<int[]> sBlock5 = new List<int[]>();
        public List<int[]> sBlock6 = new List<int[]>();
        public List<int[]> sBlock7 = new List<int[]>();
        public List<int[]> sBlock8 = new List<int[]>();
        List<BitArray> keys = new List<BitArray>();

        public DESalg(BitArray key)
        {
            int[] row1s1 = { 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7 };
            int[] row2s1 = { 0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8 };
            int[] row3s1 = { 4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0 };
            int[] row4s1 = { 15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 };
            sBlock1.Add(row1s1);
            sBlock1.Add(row2s1);
            sBlock1.Add(row3s1);
            sBlock1.Add(row4s1);

            int[] row1s2 = { 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10 };
            int[] row2s2 = { 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5 };
            int[] row3s2 = { 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15 };
            int[] row4s2 = { 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 };
            sBlock2.Add(row1s2);
            sBlock2.Add(row2s2);
            sBlock2.Add(row3s2);
            sBlock2.Add(row4s2);

            int[] row1s3 = { 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8 };
            int[] row2s3 = { 13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1 };
            int[] row3s3 = { 13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7 };
            int[] row4s3 = { 1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 };
            sBlock3.Add(row1s3);
            sBlock3.Add(row2s3);
            sBlock3.Add(row3s3);
            sBlock3.Add(row4s3);

            int[] row1s4 = { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15 };
            int[] row2s4 = { 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9 };
            int[] row3s4 = { 10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4 };
            int[] row4s4 = { 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 };
            sBlock4.Add(row1s4);
            sBlock4.Add(row2s4);
            sBlock4.Add(row3s4);
            sBlock4.Add(row4s4);

            int[] row1s5 = { 2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9 };
            int[] row2s5 = { 14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6 };
            int[] row3s5 = { 4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14 };
            int[] row4s5 = { 11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 };
            sBlock5.Add(row1s5);
            sBlock5.Add(row2s5);
            sBlock5.Add(row3s5);
            sBlock5.Add(row4s5);

            int[] row1s6 = { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 };
            int[] row2s6 = { 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8 };
            int[] row3s6 = { 9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6 };
            int[] row4s6 = { 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 };
            sBlock6.Add(row1s6);
            sBlock6.Add(row2s6);
            sBlock6.Add(row3s6);
            sBlock6.Add(row4s6);

            int[] row1s7 = { 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1 };
            int[] row2s7 = { 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6 };
            int[] row3s7 = { 1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2 };
            int[] row4s7 = { 6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 };
            sBlock7.Add(row1s7);
            sBlock7.Add(row2s7);
            sBlock7.Add(row3s7);
            sBlock7.Add(row4s7);

            int[] row1s8 = { 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7 };
            int[] row2s8 = { 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2 };
            int[] row3s8 = { 7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8 };
            int[] row4s8 = { 2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 };
            sBlock8.Add(row1s8);
            sBlock8.Add(row2s8);
            sBlock8.Add(row3s8);
            sBlock8.Add(row4s8);


            keys = GenerateKeys(key);
        }
        //generise 16 kljuceva koji se koriste u enkripciji id ekripciji
        private List<BitArray> GenerateKeys(BitArray key)
        {
            List<BitArray> returnList = new List<BitArray>();
            BitArray key56 = new BitArray(56);
            int j = 0;
            for(int i = 0; i < key.Count-1; i++)
            {
                if ((i + 1) % 8 == 0)
                    i++;
                key56[j] = key[i];
                j++;
            }

            BitArray c = new BitArray(28);
            BitArray d = new BitArray(28);
            
            for (int i = 0; i < 28; i++)
            {
                c[i] = key56[i];
                d[i] = key56[i + 28];
            }

            BitArray c1 = new BitArray(Shift1(c));
            BitArray d1 = new BitArray(Shift1(d));

            BitArray shift1Key = new BitArray(56);
            for(int i = 0; i < 28; i++)
            {
                shift1Key[i] = c1[i];
                shift1Key[i + 28] = d1[i];
            }

            BitArray keyS1 = new BitArray(GetKey48(shift1Key));
            c1 = new BitArray(Shift2(c));
            d1 = new BitArray(Shift2(d));

            BitArray shift2Key = new BitArray(56);
            for (int i = 0; i < 28; i++)
            {
                shift2Key[i] = c1[i];
                shift2Key[i + 28] = d1[i];
            }

            BitArray keyS2 = new BitArray(GetKey48(shift2Key));
            returnList.Add(keyS1);
            returnList.Add(keyS1);
            returnList.Add(keyS2);
            returnList.Add(keyS2);
            returnList.Add(keyS2);
            returnList.Add(keyS2);
            returnList.Add(keyS2);
            returnList.Add(keyS2);
            returnList.Add(keyS1);
            returnList.Add(keyS2);
            returnList.Add(keyS2);
            returnList.Add(keyS2);
            returnList.Add(keyS2);
            returnList.Add(keyS2);
            returnList.Add(keyS2);
            returnList.Add(keyS1);
            return returnList;
        }
        //od 56bitnog kljuca pravi ljuc od 48 bita
        private BitArray GetKey48(BitArray key)
        {
            BitArray subKey = new BitArray(48);
            subKey[0] = key[4];
            subKey[1] = key[23];
            subKey[2] = key[6];
            subKey[3] = key[15];
            subKey[4] = key[5];
            subKey[5] = key[9];
            subKey[6] = key[19];
            subKey[7] = key[17];
            subKey[8] = key[11];
            subKey[9] = key[2];
            subKey[10] = key[14];
            subKey[11] = key[22];
            subKey[12] = key[0];
            subKey[13] = key[8];
            subKey[14] = key[18];
            subKey[15] = key[1];
            subKey[16] = key[13];
            subKey[17] = key[21];
            subKey[18] = key[10];
            subKey[19] = key[12];
            subKey[20] = key[3];
            subKey[21] = key[16];
            subKey[22] = key[20];
            subKey[23] = key[7];
            subKey[24] = key[46];
            subKey[25] = key[30];
            subKey[26] = key[26];
            subKey[27] = key[47];
            subKey[28] = key[34];
            subKey[29] = key[40];
            subKey[30] = key[45];
            subKey[31] = key[27];
            subKey[32] = key[38];
            subKey[33] = key[31];
            subKey[34] = key[24];
            subKey[35] = key[43];
            subKey[36] = key[36];
            subKey[37] = key[33];
            subKey[38] = key[42];
            subKey[39] = key[28];
            subKey[40] = key[35];
            subKey[41] = key[37];
            subKey[42] = key[44];
            subKey[43] = key[32];
            subKey[44] = key[25];
            subKey[45] = key[41];
            subKey[46] = key[29];
            subKey[47] = key[39];
            return subKey;

        }
        //ispisuje niz bita
        public void printBitArray(BitArray array, string type)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i])
                    Console.Write("1");
                else
                    Console.Write("0");
                if ((i + 1) % 8 == 0)
                    Console.Write(" ");
            }
            Console.WriteLine(" {0}", type);
        }
        //siftuje bite za 1 u levo
        public BitArray Shift1(BitArray array)
        {
            BitArray returnArray = new BitArray(array.Count);
            for (int i = 0; i < array.Count - 1; i++)
            {
                returnArray[i] = array[i + 1];
            }
            returnArray[array.Count - 1] = array[0];
            return returnArray;
        }
        //siftuje bite za 2 u levo
        public BitArray Shift2(BitArray array)
        {
            BitArray returnArray = new BitArray(array.Count);
            for (int i = 0; i < array.Count - 2; i++)
            {
                returnArray[i] = array[i + 2];
            }
            returnArray[array.Count - 2] = array[0];
            returnArray[array.Count - 1] = array[1];
            return returnArray;
        }
        //enkriptuje poruku
        public BitArray Encrypt(BitArray message, BitArray IV)
        {
            message.Xor(IV);
            BitArray crypted = new BitArray(InitialPermutation(message));
            BitArray L = new BitArray(32);
            BitArray R = new BitArray(32);

            for(int i = 0; i < 32; i++)
            {
                L[i] = crypted[i];
                R[i] = crypted[i + 32];
            }

            BitArray L1 = new BitArray(R);
            BitArray R1 = new BitArray(fFunction(R, keys[0]));
            R1.Xor(L);
            BitArray L2 = new BitArray(R1);
            BitArray R2 = new BitArray(fFunction(R1, keys[1]));
            R1.Xor(L1);
            BitArray L3 = new BitArray(R2);
            BitArray R3 = new BitArray(fFunction(R2, keys[2]));
            R1.Xor(L2);
            BitArray L4 = new BitArray(R3);
            BitArray R4 = new BitArray(fFunction(R3, keys[3]));
            R1.Xor(L3);
            BitArray L5 = new BitArray(R4);
            BitArray R5 = new BitArray(fFunction(R4, keys[4]));
            R1.Xor(L4);
            BitArray L6 = new BitArray(R5);
            BitArray R6 = new BitArray(fFunction(R5, keys[5]));
            R1.Xor(L5);
            BitArray L7 = new BitArray(R6);
            BitArray R7 = new BitArray(fFunction(R6, keys[6]));
            R1.Xor(L6);
            BitArray L8 = new BitArray(R7);
            BitArray R8 = new BitArray(fFunction(R7, keys[7]));
            R1.Xor(L7);
            BitArray L9 = new BitArray(R8);
            BitArray R9 = new BitArray(fFunction(R8, keys[8]));
            R1.Xor(L8);
            BitArray L10 = new BitArray(R9);
            BitArray R10 = new BitArray(fFunction(R9, keys[9]));
            R1.Xor(L9);
            BitArray L11 = new BitArray(R10);
            BitArray R11 = new BitArray(fFunction(R10, keys[10]));
            R1.Xor(L10);
            BitArray L12 = new BitArray(R11);
            BitArray R12 = new BitArray(fFunction(R11, keys[11]));
            R1.Xor(L11);
            BitArray L13 = new BitArray(R12);
            BitArray R13 = new BitArray(fFunction(R12, keys[12]));
            R1.Xor(L12);
            BitArray L14 = new BitArray(R13);
            BitArray R14 = new BitArray(fFunction(R13, keys[13]));
            R1.Xor(L13);
            BitArray L15 = new BitArray(R14);
            BitArray R15 = new BitArray(fFunction(R14, keys[14]));
            R1.Xor(L14);
            BitArray L16 = new BitArray(R15);
            BitArray R16 = new BitArray(fFunction(R15, keys[15]));
            R1.Xor(L15);
            for (int i = 0; i < 32; i++)
            {
                crypted[i] = L16[i];
                crypted[i + 32] = R16[i];
            }
            message = new BitArray(FinalPermutation(crypted));
            return message;
        }
        //vrsi finalno premutovanje bita enkriptovane/dekriptovane poruke
        private BitArray FinalPermutation(BitArray message)
        {
            BitArray returnArray = new BitArray(64);
            returnArray[0] = message[39];
            returnArray[1] = message[8];
            returnArray[2] = message[47];
            returnArray[3] = message[15];
            returnArray[4] = message[55];
            returnArray[5] = message[23];
            returnArray[6] = message[63];
            returnArray[7] = message[31];
            returnArray[8] = message[38];
            returnArray[9] = message[6];
            returnArray[10] = message[46];
            returnArray[11] = message[14];
            returnArray[12] = message[54];
            returnArray[13] = message[22];
            returnArray[14] = message[62];
            returnArray[15] = message[30];
            returnArray[16] = message[37];
            returnArray[17] = message[5];
            returnArray[18] = message[46];
            returnArray[19] = message[13];
            returnArray[20] = message[53];
            returnArray[21] = message[21];
            returnArray[22] = message[61];
            returnArray[23] = message[29];
            returnArray[24] = message[36];
            returnArray[25] = message[4];
            returnArray[26] = message[44];
            returnArray[27] = message[12];
            returnArray[28] = message[52];
            returnArray[29] = message[20];
            returnArray[30] = message[60];
            returnArray[31] = message[28];
            returnArray[32] = message[35];
            returnArray[33] = message[3];
            returnArray[34] = message[43];
            returnArray[35] = message[11];
            returnArray[36] = message[51];
            returnArray[37] = message[19];
            returnArray[38] = message[59];
            returnArray[39] = message[27];
            returnArray[40] = message[34];
            returnArray[41] = message[2];
            returnArray[42] = message[42];
            returnArray[43] = message[10];
            returnArray[44] = message[50];
            returnArray[45] = message[18];
            returnArray[46] = message[58];
            returnArray[47] = message[26];
            returnArray[48] = message[33];
            returnArray[49] = message[1];
            returnArray[50] = message[41];
            returnArray[51] = message[9];
            returnArray[52] = message[49];
            returnArray[53] = message[17];
            returnArray[54] = message[57];
            returnArray[55] = message[25];
            returnArray[56] = message[33];
            returnArray[57] = message[0];
            returnArray[58] = message[40];
            returnArray[59] = message[8];
            returnArray[60] = message[48];
            returnArray[61] = message[16];
            returnArray[62] = message[56];
            returnArray[63] = message[24];
            return returnArray;
        }
        //kriptuje/dekriptuje desna 32 bita poruke
        private BitArray fFunction(BitArray R, BitArray key)
        {
            BitArray expanded = new BitArray(Expand(R));
            printBitArray(expanded, "expanded");
            expanded.Xor(key);
            printBitArray(expanded, "xor");
            List<BitArray> blocks = new List<BitArray>();
            BitArray temp1 = new BitArray(6);
            BitArray temp2 = new BitArray(6);
            BitArray temp3 = new BitArray(6);
            BitArray temp4 = new BitArray(6);
            BitArray temp5 = new BitArray(6);
            BitArray temp6 = new BitArray(6);
            BitArray temp7 = new BitArray(6);
            BitArray temp8 = new BitArray(6);
            for (int i = 0; i < 6; i++)
            {
                temp1[i] = expanded[i];
                temp2[i] = expanded[i + 6];
                temp3[i] = expanded[i + 12];
                temp4[i] = expanded[i + 18];
                temp5[i] = expanded[i + 24];
                temp6[i] = expanded[i + 30];
                temp7[i] = expanded[i + 36];
                temp8[i] = expanded[i + 42];
            }
            blocks.Add(temp1);
            blocks.Add(temp2);
            blocks.Add(temp3);
            blocks.Add(temp4);
            blocks.Add(temp5);
            blocks.Add(temp6);
            blocks.Add(temp7);
            blocks.Add(temp8);
            for(int i = 0; i < 8; i++)
            {
                printBitArray(blocks[i], string.Format("block {0}", i));
            }

            temp1 = new BitArray(sFunction(blocks[0],1));
            printBitArray(temp1, "sfun 1");
            temp2 = new BitArray(sFunction(blocks[1],2));
            printBitArray(temp2, "sfun 2");
            temp3 = new BitArray(sFunction(blocks[2],3));
            printBitArray(temp3, "sfun 3");
            temp4 = new BitArray(sFunction(blocks[3],4));
            printBitArray(temp4, "sfun 4");
            temp5 = new BitArray(sFunction(blocks[4],5));
            printBitArray(temp5, "sfun 5");
            temp6 = new BitArray(sFunction(blocks[5],6));
            printBitArray(temp6, "sfun 6");
            temp7 = new BitArray(sFunction(blocks[6],7));
            printBitArray(temp7, "sfun 7");
            temp8 = new BitArray(sFunction(blocks[7],8));
            printBitArray(temp8, "sfun 8");
            BitArray sBox = new BitArray(32);
            for(int i = 0; i < 4; i++)
            {
                sBox[i] = temp1[i];
                sBox[i+4] = temp2[i];
                sBox[i+8] = temp3[i];
                sBox[i+12] = temp4[i];
                sBox[i+16] = temp5[i];
                sBox[i+20] = temp6[i];
                sBox[i+24] = temp7[i];
                sBox[i+28] = temp8[i];
            }
            printBitArray(sBox, "sboxout");
            BitArray finish = new BitArray(PermuteS(sBox));
            printBitArray(finish, "finish");
            return finish;

        }
        //permutuje bite dobijene iz sBoxova
        private BitArray PermuteS(BitArray sBoxOut)
        {
            BitArray returnArray = new BitArray(32);
            returnArray[0] = sBoxOut[15];
            returnArray[1] = sBoxOut[6];
            returnArray[2] = sBoxOut[19];
            returnArray[3] = sBoxOut[20];
            returnArray[4] = sBoxOut[28];
            returnArray[5] = sBoxOut[11];
            returnArray[6] = sBoxOut[27];
            returnArray[7] = sBoxOut[16];
            returnArray[8] = sBoxOut[0];
            returnArray[9] = sBoxOut[14];
            returnArray[10] = sBoxOut[22];
            returnArray[11] = sBoxOut[25];
            returnArray[12] = sBoxOut[4];
            returnArray[13] = sBoxOut[19];
            returnArray[14] = sBoxOut[30];
            returnArray[15] = sBoxOut[9];
            returnArray[16] = sBoxOut[1];
            returnArray[17] = sBoxOut[7];
            returnArray[18] = sBoxOut[23];
            returnArray[19] = sBoxOut[13];
            returnArray[20] = sBoxOut[31];
            returnArray[21] = sBoxOut[26];
            returnArray[22] = sBoxOut[2];
            returnArray[23] = sBoxOut[8];
            returnArray[24] = sBoxOut[18];
            returnArray[25] = sBoxOut[12];
            returnArray[26] = sBoxOut[29];
            returnArray[27] = sBoxOut[5];
            returnArray[28] = sBoxOut[21];
            returnArray[29] = sBoxOut[10];
            returnArray[30] = sBoxOut[3];
            returnArray[31] = sBoxOut[24];
            return returnArray;
        }
        //izvlaci odgovarajuce vrednosti iz sBoxova
        private BitArray sFunction(BitArray B, int block)
        {
            BitArray returnArray = new BitArray(4);
            BitArray numberRow = new BitArray(32);
            BitArray numberColomn = new BitArray(32);

            numberColomn[3] = B[1];
            numberColomn[2] = B[2];
            numberColomn[1] = B[3];
            numberColomn[0] = B[4];

            numberRow[1] = B[0];
            numberRow[0] = B[5];

            int[] r = new int[1];
            int[] c = new int[1];
            int value = 0;
            numberRow.CopyTo(r, 0);
            numberColomn.CopyTo(c, 0);
            switch (block)
            {
                case 1:
                    switch (r[0])
                    {
                        case 0:
                            value = sBlock1[0][c[0]];
                            break;
                        case 1:
                            value = sBlock1[1][c[0]];
                            break;
                        case 2:
                            value = sBlock1[2][c[0]];
                            break;
                        default:
                            value = sBlock1[3][c[0]];
                            break;
                    }
                    break;
                case 2:
                    switch (r[0])
                    {
                        case 0:
                            value = sBlock2[0][c[0]];
                            break;
                        case 1:
                            value = sBlock2[1][c[0]];
                            break;
                        case 2:
                            value = sBlock2[2][c[0]];
                            break;
                        default:
                            value = sBlock2[3][c[0]];
                            break;
                    }
                    break;
                case 3:
                    switch (r[0])
                    {
                        case 0:
                            value = sBlock3[0][c[0]];
                            break;
                        case 1:
                            value = sBlock3[1][c[0]];
                            break;
                        case 2:
                            value = sBlock3[2][c[0]];
                            break;
                        default:
                            value = sBlock3[3][c[0]];
                            break;
                    }
                    break;
                case 4:
                    switch (r[0])
                    {
                        case 0:
                            value = sBlock4[0][c[0]];
                            break;
                        case 1:
                            value = sBlock4[1][c[0]];
                            break;
                        case 2:
                            value = sBlock4[2][c[0]];
                            break;
                        default:
                            value = sBlock4[3][c[0]];
                            break;
                    }
                    break;
                case 5:
                    switch (r[0])
                    {
                        case 0:
                            value = sBlock5[0][c[0]];
                            break;
                        case 1:
                            value = sBlock5[1][c[0]];
                            break;
                        case 2:
                            value = sBlock5[2][c[0]];
                            break;
                        default:
                            value = sBlock5[3][c[0]];
                            break;
                    }
                    break;
                case 6:
                    switch (r[0])
                    {
                        case 0:
                            value = sBlock6[0][c[0]];
                            break;
                        case 1:
                            value = sBlock6[1][c[0]];
                            break;
                        case 2:
                            value = sBlock6[2][c[0]];
                            break;
                        default:
                            value = sBlock6[3][c[0]];
                            break;
                    }
                    break;
                case 7:
                    switch (r[0])
                    {
                        case 0:
                            value = sBlock7[0][c[0]];
                            break;
                        case 1:
                            value = sBlock7[1][c[0]];
                            break;
                        case 2:
                            value = sBlock7[2][c[0]];
                            break;
                        default:
                            value = sBlock7[3][c[0]];
                            break;
                    }
                    break;
                default:
                    switch (r[0])
                    {
                        case 0:
                            value = sBlock8[0][c[0]];
                            break;
                        case 1:
                            value = sBlock8[1][c[0]];
                            break;
                        case 2:
                            value = sBlock8[2][c[0]];
                            break;
                        default:
                            value = sBlock8[3][c[0]];
                            break;
                    }
                    break;
            }
            BitArray b = new BitArray(new int[] { value });
            returnArray[3] = b[0];
            returnArray[2] = b[1];
            returnArray[1] = b[2];
            returnArray[0] = b[3];
            return returnArray;
        }
        //Prosiruje 32 bitni niz u 48bitni niz
        private BitArray Expand(BitArray array)
        {
            BitArray returnArray = new BitArray(48);
            returnArray[0] = array[31];
            returnArray[1] = array[0];
            returnArray[2] = array[1];
            returnArray[3] = array[2];
            returnArray[4] = array[3];
            returnArray[5] = array[4];
            returnArray[6] = array[3];
            returnArray[7] = array[4];
            returnArray[8] = array[5];
            returnArray[9] = array[6];
            returnArray[10] = array[7];
            returnArray[11] = array[8];
            returnArray[12] = array[7];
            returnArray[13] = array[8];
            returnArray[14] = array[9];
            returnArray[15] = array[10];
            returnArray[16] = array[11];
            returnArray[17] = array[12];
            returnArray[18] = array[11];
            returnArray[19] = array[12];
            returnArray[20] = array[13];
            returnArray[21] = array[14];
            returnArray[22] = array[15];
            returnArray[23] = array[16];
            returnArray[24] = array[15];
            returnArray[25] = array[16];
            returnArray[26] = array[17];
            returnArray[27] = array[18];
            returnArray[28] = array[19];
            returnArray[29] = array[20];
            returnArray[30] = array[19];
            returnArray[31] = array[20];
            returnArray[32] = array[21];
            returnArray[33] = array[22];
            returnArray[34] = array[23];
            returnArray[35] = array[24];
            returnArray[36] = array[23];
            returnArray[37] = array[24];
            returnArray[38] = array[25];
            returnArray[39] = array[26];
            returnArray[40] = array[27];
            returnArray[41] = array[28];
            returnArray[42] = array[27];
            returnArray[43] = array[28];
            returnArray[44] = array[29];
            returnArray[45] = array[30];
            returnArray[46] = array[31];
            returnArray[47] = array[0];
            return returnArray;
        }
        //inicijalna permutacija poruke
        private BitArray InitialPermutation(BitArray message)
        {
            BitArray mess = new BitArray(64);
            mess[0] = message[57];
            mess[1] = message[49];
            mess[2] = message[41];
            mess[3] = message[33];
            mess[4] = message[25];
            mess[5] = message[17];
            mess[6] = message[9];
            mess[7] = message[1];
            mess[8] = message[59];
            mess[9] = message[51];
            mess[10] = message[43];
            mess[11] = message[35];
            mess[12] = message[27];
            mess[13] = message[19];
            mess[14] = message[11];
            mess[15] = message[3];
            mess[16] = message[61];
            mess[17] = message[53];
            mess[18] = message[45];
            mess[19] = message[37];
            mess[20] = message[29];
            mess[21] = message[21];
            mess[22] = message[13];
            mess[23] = message[5];
            mess[24] = message[63];
            mess[25] = message[55];
            mess[26] = message[47];
            mess[27] = message[40];
            mess[28] = message[31];
            mess[29] = message[23];
            mess[30] = message[15];
            mess[31] = message[7];
            mess[32] = message[56];
            mess[33] = message[48];
            mess[34] = message[40];
            mess[35] = message[32];
            mess[36] = message[24];
            mess[37] = message[16];
            mess[38] = message[8];
            mess[39] = message[0];
            mess[40] = message[58];
            mess[41] = message[50];
            mess[42] = message[42];
            mess[43] = message[34];
            mess[44] = message[26];
            mess[45] = message[18];
            mess[46] = message[10];
            mess[47] = message[2];
            mess[48] = message[60];
            mess[49] = message[52];
            mess[50] = message[44];
            mess[51] = message[36];
            mess[52] = message[28];
            mess[53] = message[20];
            mess[54] = message[12];
            mess[55] = message[4];
            mess[56] = message[62];
            mess[57] = message[54];
            mess[58] = message[46];
            mess[59] = message[38];
            mess[60] = message[30];
            mess[61] = message[22];
            mess[62] = message[14];
            mess[63] = message[6];
            return mess;
        }
        //dekriptuje poruku
        public BitArray Decrypt(BitArray message, BitArray IV)
        {
            message.Xor(IV);
            BitArray decrypted = new BitArray(InitialPermutation(message));
            BitArray L = new BitArray(32);
            BitArray R = new BitArray(32);

            for (int i = 0; i < 32; i++)
            {
                L[i] = decrypted[i+32];
                R[i] = decrypted[i];
            }
            BitArray L1 = new BitArray(R);
            BitArray R1 = new BitArray(fFunction(R, keys[15]));
            R1.Xor(L);
            BitArray L2 = new BitArray(R1);
            BitArray R2 = new BitArray(fFunction(R1, keys[14]));
            R1.Xor(L1);
            BitArray L3 = new BitArray(R2);
            BitArray R3 = new BitArray(fFunction(R2, keys[13]));
            R1.Xor(L2);
            BitArray L4 = new BitArray(R3);
            BitArray R4 = new BitArray(fFunction(R3, keys[12]));
            R1.Xor(L3);
            BitArray L5 = new BitArray(R4);
            BitArray R5 = new BitArray(fFunction(R4, keys[11]));
            R1.Xor(L4);
            BitArray L6 = new BitArray(R5);
            BitArray R6 = new BitArray(fFunction(R5, keys[10]));
            R1.Xor(L5);
            BitArray L7 = new BitArray(R6);
            BitArray R7 = new BitArray(fFunction(R6, keys[9]));
            R1.Xor(L6);
            BitArray L8 = new BitArray(R7);
            BitArray R8 = new BitArray(fFunction(R7, keys[8]));
            R1.Xor(L7);
            BitArray L9 = new BitArray(R8);
            BitArray R9 = new BitArray(fFunction(R8, keys[7]));
            R1.Xor(L8);
            BitArray L10 = new BitArray(R9);
            BitArray R10 = new BitArray(fFunction(R9, keys[6]));
            R1.Xor(L9);
            BitArray L11 = new BitArray(R10);
            BitArray R11 = new BitArray(fFunction(R10, keys[5]));
            R1.Xor(L10);
            BitArray L12 = new BitArray(R11);
            BitArray R12 = new BitArray(fFunction(R11, keys[4]));
            R1.Xor(L11);
            BitArray L13 = new BitArray(R12);
            BitArray R13 = new BitArray(fFunction(R12, keys[3]));
            R1.Xor(L12);
            BitArray L14 = new BitArray(R13);
            BitArray R14 = new BitArray(fFunction(R13, keys[2]));
            R1.Xor(L13);
            BitArray L15 = new BitArray(R14);
            BitArray R15 = new BitArray(fFunction(R14, keys[4]));
            R1.Xor(L14);
            BitArray L16 = new BitArray(R15);
            BitArray R16 = new BitArray(fFunction(R15, keys[0]));
            R1.Xor(L15);

            for (int i = 0; i < 32; i++)
            {
                decrypted[i+32] = L1[i];
                decrypted[i] = R1[i];
            }

            message = new BitArray(FinalPermutation(decrypted));

            return message;
        }
        //pretvara string u niz bita
        public BitArray ConvertToBits(string mess)
        {
            byte[] toBytes = Encoding.ASCII.GetBytes(mess);
            BitArray returnArray = new BitArray(toBytes);
            return returnArray;
        }
        //pretvara niz bita u string
        public string ConvertToMessage(BitArray mess)
        {
            byte[] bytes = new byte[8];
            mess.CopyTo(bytes, 0);
            string str = System.Text.Encoding.Default.GetString(bytes);
            return str;
        }
    }
}
