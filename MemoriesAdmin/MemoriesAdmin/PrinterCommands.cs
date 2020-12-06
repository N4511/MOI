using System;
using System.Collections.Generic;
using System.Text;

namespace MemoriesAdmin
{

    public class Commands
    {
        // Feed control sequences
        public static readonly byte[] CTL_LF = new byte[] { 0x0a }; // Print and line feed

        // Beeper
        public static byte[] BEEPER = new byte[] { 0x1b, 0x42, 0x05, 0x09 }; // Beeps 5 times for 9*50ms each time

        // Line Spacing
        public static readonly byte[] LINE_SPACE_24 = new byte[] { 0x1b, 0x33, 24 }; // Set the line spacing at 24
        public static readonly byte[] LINE_SPACE_30 = new byte[] { 0x1b, 0x33, 30 }; // Set the line spacing at 30

        //Image
        public static readonly byte[] SELECT_BIT_IMAGE_MODE = new byte[] { 0x1B, 0x2A, 33 };

        public static readonly byte[] NEW_LINE = new byte[] { 0x0A };

        public static readonly byte[] QR_CODE = new byte[] { 0x1B, 0x5A, 0x00, 0x02, 0x06, 0x17, 0x00 };
        // Printer hardware, 
        public static readonly byte[] HW_INIT = new byte[] { 0x1B, 0x40 }; // Clear data in buffer and reset modes

        // Cash Drawer
        public static readonly byte[] CD_KICK_2 = new byte[] { 0x1b, 0x70, 0x00 }; // Sends a pulse to pin 2 []
        public static readonly byte[] CD_KICK_5 = new byte[] { 0x1b, 0x70, 0x01 }; // Sends a pulse to pin 5 []

        // Paper
        public static readonly byte[] PAPER_FULL_CUT = new byte[] { 0x1d, 0x56, 0x00 }; // Full cut paper
        public static readonly byte[] PAPER_PART_CUT = new byte[] { 0x1d, 0x56, 0x01 }; // Partial cut paper

        // Text format
        public static readonly byte[] TXT_NORMAL = new byte[] { 0x1b, 0x21, 0x00 }; // Normal text
        public static readonly byte[] TXT_2HEIGHT = new byte[] { 0x1b, 0x21, 0x10 }; // Double height text
        public static readonly byte[] TXT_2WIDTH = new byte[] { 0x1b, 0x21, 0x20 }; // Double width text
        public static readonly byte[] TXT_4SQUARE = new byte[] { 0x1b, 0x21, 0x30 }; // Quad area text
        public static readonly byte[] TXT_UNDERL_OFF = new byte[] { 0x1b, 0x2d, 0x00 }; // Underline font OFF
        public static readonly byte[] TXT_UNDERL_ON = new byte[] { 0x1b, 0x2d, 0x01 }; // Underline font 1-dot ON
        public static readonly byte[] TXT_UNDERL2_ON = new byte[] { 0x1b, 0x2d, 0x02 }; // Underline font 2-dot ON
        public static readonly byte[] TXT_BOLD_OFF = new byte[] { 0x1b, 0x45, 0x00 }; // Bold font OFF
        public static readonly byte[] TXT_BOLD_ON = new byte[] { 0x1b, 0x45, 0x01 }; // Bold font ON
        public static readonly byte[] TXT_FONT_A = new byte[] { 0x1b, 0x4d, 0x48 }; // Font type A
        public static readonly byte[] TXT_FONT_B = new byte[] { 0x1b, 0x4d, 0x01 }; // Font type B
        public static readonly byte[] TXT_ALIGN_LT = new byte[] { 0x1b, 0x61, 0x00 }; // Left justification
        public static readonly byte[] TXT_ALIGN_CT = new byte[] { 0x1b, 0x61, 0x01 }; // Centering
        public static readonly byte[] TXT_ALIGN_RT = new byte[] { 0x1b, 0x61, 0x02 }; // Right justification

        // Char code table
        public static readonly byte[] CHARCODE_PC437 = new byte[] { 0x1b, 0x74, 0x00 }; // USA){ Standard Europe
        public static readonly byte[] CHARCODE_JIS = new byte[] { 0x1b, 0x74, 0x01 }; // Japanese Katakana
        public static readonly byte[] CHARCODE_PC850 = new byte[] { 0x1b, 0x74, 0x02 }; // Multilingual
        public static readonly byte[] CHARCODE_PC860 = new byte[] { 0x1b, 0x74, 0x03 }; // Portuguese
        public static readonly byte[] CHARCODE_PC863 = new byte[] { 0x1b, 0x74, 0x04 }; // Canadian-French
        public static readonly byte[] CHARCODE_PC865 = new byte[] { 0x1b, 0x74, 0x05 }; // Nordic
        public static readonly byte[] CHARCODE_WEU = new byte[] { 0x1b, 0x74, 0x06 }; // Simplified Kanji, Hirakana
        public static readonly byte[] CHARCODE_GREEK = new byte[] { 0x1b, 0x74, 0x07 }; // Simplified Kanji
        public static readonly byte[] CHARCODE_HEBREW = new byte[] { 0x1b, 0x74, 0x08 }; // Simplified Kanji
        public static readonly byte[] CHARCODE_PC1252 = new byte[] { 0x1b, 0x74, 0x10 }; // Western European Windows Code Set
        public static readonly byte[] CHARCODE_PC866 = new byte[] { 0x1b, 0x74, 0x12 }; // Cirillic //2
        public static readonly byte[] CHARCODE_PC852 = new byte[] { 0x1b, 0x74, 0x13 }; // Latin 2
        public static readonly byte[] CHARCODE_PC858 = new byte[] { 0x1b, 0x74, 0x14 }; // Euro
        public static readonly byte[] CHARCODE_THAI42 = new byte[] { 0x1b, 0x74, 0x15 }; // Thai character code 42
        public static readonly byte[] CHARCODE_THAI11 = new byte[] { 0x1b, 0x74, 0x16 }; // Thai character code 11
        public static readonly byte[] CHARCODE_THAI13 = new byte[] { 0x1b, 0x74, 0x17 }; // Thai character code 13
        public static readonly byte[] CHARCODE_THAI14 = new byte[] { 0x1b, 0x74, 0x18 }; // Thai character code 14
        public static readonly byte[] CHARCODE_THAI16 = new byte[] { 0x1b, 0x74, 0x19 }; // Thai character code 16
        public static readonly byte[] CHARCODE_THAI17 = new byte[] { 0x1b, 0x74, 0x1a }; // Thai character code 17
        public static readonly byte[] CHARCODE_THAI18 = new byte[] { 0x1b, 0x74, 0x1b }; // Thai character code 18

        // Barcode format
        public static readonly byte[] BARCODE_TXT_OFF = new byte[] { 0x1d, 0x48, 0x00 }; // HRI printBarcode chars OFF
        public static readonly byte[] BARCODE_TXT_ABV = new byte[] { 0x1d, 0x48, 0x01 }; // HRI printBarcode chars above
        public static readonly byte[] BARCODE_TXT_BLW = new byte[] { 0x1d, 0x48, 0x02 }; // HRI printBarcode chars below
        public static readonly byte[] BARCODE_TXT_BTH = new byte[] { 0x1d, 0x48, 0x03 }; // HRI printBarcode chars both above and below
        public static readonly byte[] BARCODE_FONT_A = new byte[] { 0x1d, 0x66, 0x00 }; // Font type A for HRI printBarcode chars
        public static readonly byte[] BARCODE_FONT_B = new byte[] { 0x1d, 0x66, 0x01 }; // Font type B for HRI printBarcode chars
        public static readonly byte[] BARCODE_HEIGHT = new byte[] { 0x1d, 0x68, 0x64 }; // Barcode Height [1-255]
        public static readonly byte[] BARCODE_WIDTH = new byte[] { 0x1d, 0x77, 0x03 }; // Barcode Width  [2-6]
        public static readonly byte[] BARCODE_UPC_A = new byte[] { 0x1d, 0x6b, 0x00 }; // Barcode type UPC-A
        public static readonly byte[] BARCODE_UPC_E = new byte[] { 0x1d, 0x6b, 0x01 }; // Barcode type UPC-E
        public static readonly byte[] BARCODE_EAN13 = new byte[] { 0x1d, 0x6b, 0x02 }; // Barcode type EAN13
        public static readonly byte[] BARCODE_EAN8 = new byte[] { 0x1d, 0x6b, 0x03 }; // Barcode type EAN8
        public static readonly byte[] BARCODE_CODE39 = new byte[] { 0x1d, 0x6b, 0x04 }; // Barcode type CODE39
        public static readonly byte[] BARCODE_ITF = new byte[] { 0x1d, 0x6b, 0x05 }; // Barcode type ITF
        public static readonly byte[] BARCODE_NW7 = new byte[] { 0x1d, 0x6b, 0x06 }; // Barcode type NW7

        // Printing Density
        public static readonly byte[] PD_N50 = new byte[] { 0x1d, 0x7c, 0x00 }; // Printing Density -50%
        public static readonly byte[] PD_N37 = new byte[] { 0x1d, 0x7c, 0x01 }; // Printing Density -37.5%
        public static readonly byte[] PD_N25 = new byte[] { 0x1d, 0x7c, 0x02 }; // Printing Density -25%
        public static readonly byte[] PD_N12 = new byte[] { 0x1d, 0x7c, 0x03 }; // Printing Density -12.5%
        public static readonly byte[] PD_0 = new byte[] { 0x1d, 0x7c, 0x04 }; // Printing Density  0%
        public static readonly byte[] PD_P50 = new byte[] { 0x1d, 0x7c, 0x08 }; // Printing Density +50%
        public static readonly byte[] PD_P37 = new byte[] { 0x1d, 0x7c, 0x07 }; // Printing Density +37.5%
        public static readonly byte[] PD_P25 = new byte[] { 0x1d, 0x7c, 0x06 }; // Printing Density +25%
        public static readonly byte[] PD_P12 = new byte[] { 0x1d, 0x7c, 0x05 }; // Printing Density +12.5%

        // private constructor, not to be instatiated
        private Commands()
        {
        }

    }

}

