using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomLCDIndicator
{
    class KS0066Converter
    {
        Dictionary<char, byte> dictionary;
        public KS0066Converter()
        {
            dictionary = new Dictionary<char, byte> {             
            {'А',0x41},
            {'Б',0xA0},
            {'В',0x42},
            {'Г',0xA1},
            {'Д',0xE0},
            {'Е',0x45},
            {'Ё',0xA2},
            {'Ж',0xA3},
            {'З',0xA4},
            {'И',0xA5},
            {'Й',0xA6},
            {'К',0x4B},
            {'Л',0xA7},
            {'М',0x4D},
            {'Н',0x48},
            {'О',0x4F},
            {'П',0xA8},
            {'Р',0x50},
            {'С',0x43},
            {'Т',0x54},
            {'У',0xA9},
            {'Ф',0xAA},
            {'Х',0x58},
            {'Ц',0xE1},
            {'Ч',0xAB},
            {'Ш',0xAC},
            {'Щ',0xE2},
            {'Ъ',0xC2},
            {'Ы',0xAE},
            {'Ь',0xC4},
            {'Э',0xAF},
            {'Ю',0xB0},
            {'Я',0xB1},
            {'а',0x61},
            {'б',0xB2},
            {'в',0xB3},
            {'г',0xB4},
            {'д',0xE3},
            {'е',0x65},
            {'ё',0xB5},
            {'ж',0xB6},
            {'з',0xB7},
            {'и',0xB8},
            {'й',0xB9},
            {'к',0xBA},
            {'л',0xBB},
            {'м',0xBC},
            {'н',0xBD},
            {'о',0x6F},
            {'п',0xBE},
            {'р',0x70},
            {'с',0x63},
            {'т',0xBF},
            {'у',0x79},
            {'ф',0xE4},
            {'х',0x78},
            {'ц',0xE5},
            {'ч',0xC0},
            {'ш',0xC1},            
            {'щ',0xE6},
            {'ъ',0xC2},
            {'ы',0xC3},
            {'ь',0xC4},
            {'э',0xC5},
            {'ю',0xC6},
            {'я',0xC7},
            {'!',0x21},
            {'"',0x22},
            {'#',0x23},
            {'$',0x24},
            {'%',0x25},
            {'&',0x26},
            {'\'',0x27},
            {'(',0x28},
            {')',0x29},
            {'*',0x2A},
            {'+',0x2B},
            {',',0x2C},
            {'-',0x2D},
            {'.',0x2E},
            {'/',0x2F},
            {':',0x3A},
            {';',0x3B},
            {'<',0x3C},
            {'=',0x3D},
            {'>',0x3E},
            {'?',0x3F},            
            {'_',0x5F},
            {' ',0x20}
            };
        }

        public byte convertCharFromUnicodeToKS0066(char chr)
        {
            if (chr >= 'a' && chr <= 'z')
                return (byte)chr;
            if (chr >= 'A' && chr <= 'Z')
                return (byte)chr;
            if ("АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя !\"#$%&\\()*+,-./:;<=>?_".IndexOf(chr) >=0)
            {
                return dictionary[chr];
            }

            return 0x01;
        }
        public byte[] convertStringFromUnicodeToKS0066(String str)
        {
            byte[] buf = new byte[str.Length];
            for (int i = 0; i < str.Length; i++)
                buf[i] = convertCharFromUnicodeToKS0066(str[i]);
            return buf;
        }
        
    }
}
