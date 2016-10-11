using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;

/* Barcode Library
 * 
 * Written by: Brad Barnhill
 *       Date: September 21, 2007
 * 
 * This library was designed to give an easy class for developers to use when they need
 * to generate barcode images from a string of data.
 */
namespace BarCodeLib
{
        #region Enums
    public enum TYPE : int { UNSPECIFIED, UPCA, UPCE, UPC_SUPPLEMENTAL_2DIGIT, UPC_SUPPLEMENTAL_5DIGIT, EAN13, EAN8, Interleaved2of5, Standard2of5, Industrial2of5, CODE39, Codabar, PostNet, BOOKLAND, ISBN, JAN13, MSI_Mod10, MSI_2Mod10, MSI_Mod11, MSI_Mod11_Mod10, Modified_Plessey, CODE11, USD8, UCC12, UCC13, LOGMARS, CODE128 };
    public enum SaveTypes : int { JPG, BMP, PNG, GIF, TIFF, UNSPECIFIED };
        #endregion

    public class Barcode
    {
        #region Variables
        private string [] UPC_CodeA    = { "0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011" };
        private string [] UPC_CodeB    = { "0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111" };
        private string [] UPC_CodeC    = { "1110010", "1100110", "1101100", "1000010", "1011100", "1001110", "1010000", "1000100", "1001000", "1110100" };
        private string [] UPC_Pattern  = { "aaaaaa", "aababb", "aabbab", "aabbba", "abaabb", "abbaab", "abbbaa", "ababab", "ababba", "abbaba" };
        private string [] EAN_CodeA    = { "0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011" };
        private string [] EAN_CodeB    = { "0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111" };
        private string [] EAN_CodeC    = { "1110010", "1100110", "1101100", "1000010", "1011100", "1001110", "1010000", "1000100", "1001000", "1110100" };
        private string [] EAN_Pattern  = { "aaaaaa", "aababb", "aabbab", "aabbba", "abaabb", "abbaab", "abbbaa", "ababab", "ababba", "abbaba" };
        private string [] I25_Code     = { "NNWWN", "WNNNW", "NWNNW", "WWNNN", "NNWNW", "WNWNN", "NWWNN", "NNNWW", "WNNWN", "NWNWN" };
        private string [] S25_Code     = { "11101010101110", "10111010101110", "11101110101010", "10101110101110", "11101011101010", "10111011101010", "10101011101110", "10101110111010", "11101010111010", "10111010111010" };
        private string [] POSTNET_Code = { "11000", "00011", "00101", "00110", "01001", "01010", "01100", "10001", "10010", "10100"};
        private string [] BKLAND_CodeA = { "0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011" };
        private string [] BKLAND_CodeB = { "0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111" };
        private string [] BKLAND_CodeC = { "1110010", "1100110", "1101100", "1000010", "1011100", "1001110", "1010000", "1000100", "1001000", "1110100" };
        private string [] UPC_SUPP_2   = { "aa", "ab", "ba", "bb"};
        private string [] UPC_SUPP_5   = { "bbaaa", "babaa", "baaba", "baaab", "abbaa", "aabba", "aaabb", "ababa", "abaab", "aabab"};
        private string [] MSI_Code     = { "100100100100", "100100100110", "100100110100", "100100110110", "100110100100", "100110100110", "100110110100", "100110110110", "110100100100", "110100100110" };
        private string [] UPCE_Code_0  = { "bbbaaa", "bbabaa", "bbaaba", "bbaaab", "babbaa", "baabba", "baaabb", "bababa", "babaab", "baabab" };
        private string [] UPCE_Code_1  = { "aaabbb", "aababb", "aabbab", "aabbba", "abaabb", "abbaab", "abbbaa", "ababab", "ababba", "abbaba" };
        private string [] C11_Code     = { "101011", "1101011", "1001011", "1100101", "1011011", "1101101", "1001101", "1010011", "1101001", "110101", "101101", "1011001" };
        private Hashtable C39_Code     = new Hashtable(); //is initialized by init_Code39()
        private Hashtable Codabar_Code = new Hashtable(); //is initialized by init_Codabar()
        private Hashtable CountryCodes = new Hashtable(); //is initialized by init_CountryCodes()
        private DataTable C128_Code = new DataTable("C128");

        private string Raw_Data = "";
        private string Encoded_Value = "";
        private string _Country_Assigning_Manufacturer_Code = "N/A";
        private TYPE Encoded_Type = TYPE.UNSPECIFIED;
        private Image Encoded_Image = null;
        private Color _ForeColor = Color.Black;
        private Color _BackColor = Color.White;
        private bool bEncoded = false;
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.  Does not populate the raw data.  MUST be done via the RawData property before encoding.
        /// </summary>
        public Barcode()
        {
            //constructor
        }//Barcode
        /// <summary>
        /// Constructor. Populates the raw data. No whitespace will be added before or after the barcode.
        /// </summary>
        /// <param name="data">String to be encoded.</param>
        public Barcode(string data)
        {
            //constructor
            this.Raw_Data = data;
        }//Barcode
        public Barcode(string data, TYPE iType)
        {
            this.Raw_Data = data;
            this.Encoded_Type = iType;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the raw data to encode.
        /// </summary>
        public string RawData
        {
            get { return Raw_Data; }
            set { Raw_Data = value; bEncoded = false; }
        }//EncodedValue
        /// <summary>
        /// Gets the encoded value.
        /// </summary>
        public string EncodedValue
        {
            get { return Encoded_Value; }
        }//EncodedValue
        /// <summary>
        /// Gets the Country that assigned the Manufacturer Code.
        /// </summary>
        public string Country_Assigning_Manufacturer_Code
        {
            get { return _Country_Assigning_Manufacturer_Code; }
        }//Country_Assigning_Manufacturer_Code
        /// <summary>
        /// Gets or sets the Encoded Type (ex. UPC-A, EAN-13 ... etc)
        /// </summary>
        public TYPE EncodedType
        {
            set { Encoded_Type = value; }
            get { return Encoded_Type;  }
        }//EncodedType
        /// <summary>
        /// Gets the Image of the generated barcode.
        /// </summary>
        public Image EncodedImage
        {
            get { if (bEncoded) return Encoded_Image; else return null; }
        }//EncodedImage
        /// <summary>
        /// Gets or sets the color of the bars. (Default is black)
        /// </summary>
        public Color ForeColor
        {
            get { return this._ForeColor; }
            set { this._ForeColor = value; }
        }//ForeColor
        /// <summary>
        /// Gets or sets the background color. (Default is white)
        /// </summary>
        public Color BackColor
        {
            get { return this._BackColor; }
            set { this._BackColor = value; }
        }//BackColor
        #endregion

        #region Encode Functions
        #region General Encode

        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="percent">Percentage of the original size to size the result.</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(TYPE iType, string StringToEncode, double percent)
        {
            return ResizeImage(Encode(iType, StringToEncode), percent);
        }//Encode(TYPE, string, percent)
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="percent">Percentage of the original size to size the result.</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(TYPE iType, double percent)
        {
            return ResizeImage(Encode(iType), percent);
        }//Encode(TYPE, double)
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(TYPE iType, string StringToEncode, int Width, int Height)
        {
            return ResizeImage(Encode(iType, StringToEncode), Width, Height);
        }//Encode(TYPE, string, int, int)
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(TYPE iType, int Width, int Height)
        {
            return ResizeImage(Encode(iType), Width, Height);
        }//Encode(TYPE, int, int)
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <param name="percent">Percentage of the original size to size the result.</param>
        /// <returns></returns>
        public Image Encode(TYPE iType, string StringToEncode, Color DrawColor, Color BackColor, double percent)
        {
            return ResizeImage(Encode(iType, StringToEncode, DrawColor, BackColor), percent);
        }//Encode(TYPE, string, Color, Color, Double)
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(TYPE iType, string StringToEncode, Color DrawColor, Color BackColor, int Width, int Height)
        {
            return ResizeImage(Encode(iType, StringToEncode, DrawColor, BackColor), Width, Height);
        }//Encode(TYPE, string, Color, Color, int, int)
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(TYPE iType, string StringToEncode, Color DrawColor, Color BackColor)
        {
            Raw_Data = StringToEncode;
            return Encode(iType, DrawColor, BackColor);
        }//(Image)Encode(Type, string, Color, Color)
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(TYPE iType, Color DrawColor, Color BackColor)
        {
            this.BackColor = BackColor;
            this.ForeColor = DrawColor;
            return Encode(iType);
        }//(Image)Encode(TYPE, Color, Color)
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(TYPE iType, string StringToEncode)
        {
            Raw_Data = StringToEncode;
            return Encode(iType);
        }//(Image)Encode(TYPE, string)
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        public Image Encode(TYPE iType)
        {
            Encoded_Type = iType;
            return Encode();
        }//Encode()
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.
        /// </summary>
        public Image Encode()
        {
            //make sure there is something to encode
            if (Raw_Data.Trim() == "") throw new Exception("EENCODE-1: Input data not allowed to be blank.");
            if (this.EncodedType == TYPE.UNSPECIFIED) throw new Exception("EENCODE-2: Symbology type not allowed to be unspecified.");

            this.Encoded_Value = "";
            this._Country_Assigning_Manufacturer_Code = "N/A";

            switch (this.Encoded_Type)
            {
                case TYPE.UCC12:
                case TYPE.UPCA: Encode_UPCA();
                    break;
                case TYPE.UCC13:
                case TYPE.EAN13: Encode_EAN13();
                    break;
                case TYPE.Interleaved2of5: Encode_Interleaved2of5();
                    break;
                case TYPE.Standard2of5: Encode_Standard2of5();
                    break;
                case TYPE.Industrial2of5: Encode_Industrial2of5();
                    break;
                case TYPE.LOGMARS:
                case TYPE.CODE39: Encode_Code39();
                    break;
                case TYPE.Codabar: Encode_Codabar();
                    break;
                case TYPE.PostNet: Encode_PostNet();
                    break;
                case TYPE.ISBN: Encode_ISBN_Bookland();
                    break;
                case TYPE.BOOKLAND: Encode_ISBN_Bookland();
                    break;
                case TYPE.JAN13: Encode_JAN13();
                    break;
                case TYPE.UPC_SUPPLEMENTAL_2DIGIT: Encode_UPCSupplemental_2();
                    break;
                case TYPE.MSI_Mod10:
                case TYPE.MSI_2Mod10:
                case TYPE.MSI_Mod11:
                case TYPE.MSI_Mod11_Mod10:
                case TYPE.Modified_Plessey: Encode_MSI();
                    break;
                case TYPE.UPC_SUPPLEMENTAL_5DIGIT: Encode_UPCSupplemental_5();
                    break;
                case TYPE.UPCE: Encode_UPCE();
                    break;
                case TYPE.EAN8: Encode_EAN8();
                    break;
                case TYPE.USD8:
                case TYPE.CODE11: Encode_Code11();
                    break;
                case TYPE.CODE128: Encode_Code128();
                    break;
                default: throw new Exception("EENCODE-2: Unsupported encoding type specified.");
            }//switch

            return (Image)Generate_Image();
        }//Encode
        
        #endregion

        #region Symbologies
        /// <summary>
        /// Encode the raw data using the UPC-A algorithm.
        /// </summary>
        private void Encode_UPCA()
        {
            //check length of input
            if (Raw_Data.Length != 12)
                throw new Exception("EUPCA-1: Data length invalid.");

            if (!CheckNumericOnly(Raw_Data))
                throw new Exception("EUPCA-2: Numeric Data Only");

            string result = "101"; //start with guard bars
            string patterncode = UPC_Pattern[Int32.Parse(Raw_Data[0].ToString())];

            //first number
            result += UPC_CodeA[Int32.Parse(Raw_Data[0].ToString())];

            //second (group) of numbers
            int pos = 0;
            while (pos < 5)
            {
                if (patterncode[pos + 1] == 'a')
                    result += UPC_CodeA[Int32.Parse(Raw_Data[pos + 1].ToString())];
                if (patterncode[pos + 1] == 'b')
                    result += UPC_CodeB[Int32.Parse(Raw_Data[pos + 1].ToString())];
                pos++;
            }//while

            //add divider bars
            result += "01010";

            //third (group) of numbers
            pos = 0;
            while (pos < 5)
            {
                result += UPC_CodeC[Int32.Parse(Raw_Data[(pos++) + 6].ToString())];
            }//while

            //forth
            result += UPC_CodeC[Int32.Parse(Raw_Data[Raw_Data.Length - 1].ToString())];

            //add ending guard bars
            result += "101";

            Encoded_Value = result;

            //get the manufacturer assigning country
            this.init_CountryCodes();
            string twodigitCode = "0" + RawData.Substring(0, 1);
            try
            {
                _Country_Assigning_Manufacturer_Code = CountryCodes[twodigitCode].ToString();
            }//try
            catch
            {
                throw new Exception("EUPCA-3: Country assigning manufacturer code not found.");
            }//catch
            finally { CountryCodes.Clear(); }

        }//Encode_UPCA
        /// <summary>
        /// Encode the raw data using the UPC-E algorithm.
        /// </summary>
        private void Encode_UPCE()
        {
            if (Raw_Data.Length != 8 && Raw_Data.Length != 12) throw new Exception("EUPCE-1: Invalid data length. (8 or 12 numbers only)");

            if (!CheckNumericOnly(Raw_Data)) throw new Exception("EUPCE-2: Numeric only.");

            int CheckDigit = Int32.Parse(Raw_Data[Raw_Data.Length - 1].ToString());
            int NumberSystem = Int32.Parse(Raw_Data[0].ToString());

            //Convert to UPC-E from UPC-A if necessary
            if (Raw_Data.Length == 12)
            {
                string UPCECode = "";

                //break apart into components
                string Manufacturer = Raw_Data.Substring(1, 5);
                string ProductCode = Raw_Data.Substring(6, 5);

                //check for a valid number system
                if (NumberSystem != 0 && NumberSystem != 1)
                    throw new Exception("EUPCE-3: Invalid Number System (only 0 & 1 are valid)");

                if (Manufacturer.EndsWith("000") || Manufacturer.EndsWith("100") || Manufacturer.EndsWith("200") && Int32.Parse(ProductCode) <= 999)
                {
                    //rule 1
                    UPCECode += Manufacturer.Substring(0, 2); //first two of manufacturer
                    UPCECode += ProductCode.Substring(2, 3); //last three of product
                    UPCECode += Manufacturer[2].ToString(); //third of manufacturer
                }//if
                else if (Manufacturer.EndsWith("00") && Int32.Parse(ProductCode) <= 99)
                {
                    //rule 2
                    UPCECode += Manufacturer.Substring(0, 3); //first three of manufacturer
                    UPCECode += ProductCode.Substring(3, 2); //last two of product
                    UPCECode += "3"; //number 3
                }//else if
                else if (Manufacturer.EndsWith("0") && Int32.Parse(ProductCode) <= 9)
                {
                    //rule 3
                    UPCECode += Manufacturer.Substring(0, 4); //first four of manufacturer
                    UPCECode += ProductCode[4]; //last digit of product
                    UPCECode += "4"; //number 4
                }//else if
                else if (!Manufacturer.EndsWith("0") && Int32.Parse(ProductCode) <= 9 && Int32.Parse(ProductCode) >= 5)
                {
                    //rule 4
                    UPCECode += Manufacturer; //manufacturer
                    UPCECode += ProductCode[4]; //last digit of product
                }//else if
                else
                    throw new Exception("EUPCE-4: Illegal UPC-A entered for conversion.  Unable to convert.");

                Raw_Data = UPCECode;
            }//if

            //get encoding pattern 
            string pattern = "";

            if (NumberSystem == 0) pattern = UPCE_Code_0[CheckDigit];
            else pattern = UPCE_Code_1[CheckDigit];

            //encode the data
            string result = "101";

            int pos = 1;
            foreach (char c in pattern)
            {
                int i = Int32.Parse(Raw_Data[pos++].ToString());
                if (c == 'a')
                {
                    result += EAN_CodeA[i];
                }//if
                else if (c == 'b')
                {
                    result += EAN_CodeB[i];
                }//else if
            }//foreach

            //guard bars
            result += "01010";

            //end bars
            result += "1";

            Encoded_Value = result;
        }//Encode_UPCE
        /// <summary>
        /// Encode the raw data using the UPC Supplemental 2-digit algorithm.
        /// </summary>
        private void Encode_UPCSupplemental_2()
        {
            if (Raw_Data.Length != 2) throw new Exception("EUPC-SUP2-1: Invalid data length. (Length = 2 required)");

            if (!CheckNumericOnly(Raw_Data))
                throw new Exception("EUPC-SUP2-2: Numeric Data Only");

            string pattern = "";

            try
            {
                pattern = this.UPC_SUPP_2[Int32.Parse(Raw_Data.Trim()) % 4];
            }//try
            catch { throw new Exception("EUPC-SUP2-3: Invalid Data. (Numeric only)"); }

            string result = "1011";

            int pos = 0;
            foreach (char c in pattern)
            {
                if (c == 'a')
                {
                    //encode using odd parity
                    result += EAN_CodeA[Int32.Parse(Raw_Data[pos].ToString())];
                }//if
                else if (c == 'b')
                {
                    //encode using even parity
                    result += EAN_CodeB[Int32.Parse(Raw_Data[pos].ToString())];
                }//else if

                if (pos++ == 0) result += "01"; //Inter-character separator
            }//foreach
            Encoded_Value = result;
        }//Encode_UPSSupplemental_2
        /// <summary>
        /// Encode the raw data using the UPC Supplemental 5-digit algorithm.
        /// </summary>
        private void Encode_UPCSupplemental_5()
        {
            if (Raw_Data.Length != 5) throw new Exception("EUPC-SUP5-1: Invalid data length. (Length = 5 required).");

            if (!CheckNumericOnly(Raw_Data))
                throw new Exception("EUPCA-2: Numeric Data Only");

            //calculate the checksum digit
            int even = 0;
            int odd = 0;

            //odd
            for (int i = 0; i <= 4; i += 2)
            {
                odd += Int32.Parse(Raw_Data.Substring(i, 1)) * 3;
            }//for

            //even
            for (int i = 1; i < 4; i += 2)
            {
                even += Int32.Parse(Raw_Data.Substring(i, 1)) * 9;
            }//for

            int total = even + odd;
            int cs = total % 10;

            string pattern = UPC_SUPP_5[cs];

            string result = "";

            int pos = 0;
            foreach (char c in pattern)
            {
                //Inter-character separator
                if (pos == 0) result += "1011";
                else result += "01";

                if (c == 'a')
                {
                    //encode using odd parity
                    result += EAN_CodeA[Int32.Parse(Raw_Data[pos].ToString())];
                }//if
                else if (c == 'b')
                {
                    //encode using even parity
                    result += EAN_CodeB[Int32.Parse(Raw_Data[pos].ToString())];
                }//else if  
                pos++;
            }//foreach
            Encoded_Value = result;
        }//Encode_UPCSupplemental_5
        /// <summary>
        /// Encode the raw data using the EAN-13 algorithm. (Can include the checksum already.  If it doesnt exist in the data then it will calculate it for you.  Accepted data lengths are 12 + 1 checksum or just the 12 data digits)
        /// </summary>
        private void Encode_EAN13()
        {
            //check length of input
            if (Raw_Data.Length < 12 || Raw_Data.Length > 13)
                throw new Exception("EEAN13-1: Data length invalid.");

            if (!CheckNumericOnly(Raw_Data))
                throw new Exception("EEAN13-2: Numeric Data Only");

            string patterncode = EAN_Pattern[Int32.Parse(Raw_Data[0].ToString())];
            string result = "101";

            //first
            //result += EAN_CodeA[Int32.Parse(RawData[0].ToString())];

            //second
            int pos = 0;
            while (pos < 6)
            {
                if (patterncode[pos] == 'a')
                    result += EAN_CodeA[Int32.Parse(Raw_Data[pos + 1].ToString())];
                if (patterncode[pos] == 'b')
                    result += EAN_CodeB[Int32.Parse(Raw_Data[pos + 1].ToString())];
                pos++;
            }//while


            //add divider bars
            result += "01010";

            //get the third
            pos = 1;
            while (pos <= 5)
            {
                result += EAN_CodeC[Int32.Parse(Raw_Data[(pos++) + 6].ToString())];
            }//while

            //calculate the checksum digit
            int cs = Int32.Parse(Raw_Data[Raw_Data.Length - 1].ToString());
            if (Raw_Data.Length == 12)
            {
                int even = 0;
                int odd = 0;

                //odd
                for (int i = 0; i <= 10; i += 2)
                {
                    odd += Int32.Parse(Raw_Data.Substring(i, 1));
                }//for

                //even
                for (int i = 1; i <= 11; i += 2)
                {
                    even += Int32.Parse(Raw_Data.Substring(i, 1)) * 3;
                }//for

                int total = even + odd;
                cs = total % 10;
                cs = 10 - cs;
                if (cs == 10)
                    cs = 0;
            }//if
            //add checksum
            result += EAN_CodeC[cs];

            //add ending bars
            result += "101";

            Encoded_Value = result;

            //get the manufacturer assigning country
            init_CountryCodes();
            _Country_Assigning_Manufacturer_Code = "N/A";
            string twodigitCode = RawData.Substring(0, 2);
            string threedigitCode = RawData.Substring(0, 3);
            try
            {
                _Country_Assigning_Manufacturer_Code = CountryCodes[twodigitCode].ToString();
            }//try
            catch
            {
                try
                {
                    _Country_Assigning_Manufacturer_Code = CountryCodes[threedigitCode].ToString();
                }//try
                catch
                {
                    throw new Exception("EEAN13-3: Country assigning manufacturer code not found.");
                }//catch 
            }//catch
            finally { CountryCodes.Clear(); }
        }//Encode_EAN13
        /// <summary>
        /// Encode the raw data using the EAN-8 algorithm.
        /// </summary>
        private void Encode_EAN8()
        {
            //check length
            if (Raw_Data.Length != 8 && Raw_Data.Length != 7) throw new Exception("EEAN8-1: Invalid data length. (7 or 8 numbers only)");

            //check numeric only
            if (!CheckNumericOnly(Raw_Data)) throw new Exception("EEAN8-2: Numeric only.");

            int checksum = 0;
            //calculate the checksum digit if necessary
            if (Raw_Data.Length == 7)
            {
                //calculate the checksum digit
                int even = 0;
                int odd = 0;

                //odd
                for (int i = 0; i <= 6; i += 2)
                {
                    odd += Int32.Parse(Raw_Data.Substring(i, 1)) * 3;
                }//for

                //even
                for (int i = 1; i <= 5; i += 2)
                {
                    even += Int32.Parse(Raw_Data.Substring(i, 1));
                }//for

                int total = even + odd;
                checksum = total % 10;
                checksum = 10 - checksum;
                if (checksum == 10)
                    checksum = 0;

                //add the checksum to the end of the 
                Raw_Data += checksum.ToString();
            }//if

            //encode the data
            string result = "101";

            //first half (Encoded using left hand / odd parity)
            for (int i = 0; i < Raw_Data.Length / 2; i++)
            {
                result += EAN_CodeA[Int32.Parse(Raw_Data[i].ToString())];
            }//for

            //center guard bars
            result += "01010";

            //second half (Encoded using right hand / even parity)
            for (int i = Raw_Data.Length / 2; i < Raw_Data.Length; i++)
            {
                result += EAN_CodeC[Int32.Parse(Raw_Data[i].ToString())];
            }//for

            result += "101";

            Encoded_Value = result;
        }//Encode_EAN8
        /// <summary>
        /// Encode the raw data using the JAN-13 algorithm.
        /// </summary>
        private void Encode_JAN13()
        {
            if (!RawData.StartsWith("49")) throw new Exception("EJAN13-1: Invalid Country Code for JAN13 (49 required)");
            if (!CheckNumericOnly(Raw_Data))
                throw new Exception("EJAN13-2: Numeric Data Only");
            Encode_EAN13();
        }//Encode_JAN13
        /// <summary>
        /// Encode the raw data using the Interleaved 2 of 5 algorithm.
        /// </summary>
        private void Encode_Interleaved2of5()
        {
            //check length of input
            if (Raw_Data.Length % 2 != 0)
                throw new Exception("EI25-1: Data length invalid.");

            if (!CheckNumericOnly(Raw_Data))
                throw new Exception("EI25-2: Numeric Data Only");

            string result = "1010";

            for (int i = 0; i < Raw_Data.Length; i += 2)
            {
                bool bars = true;
                string patternbars = I25_Code[Int32.Parse(Raw_Data[i].ToString())];
                string patternspaces = I25_Code[Int32.Parse(Raw_Data[i + 1].ToString())];
                string patternmixed = "";

                //interleave
                while (patternbars.Length > 0)
                {
                    patternmixed += patternbars[0].ToString() + patternspaces[0].ToString();
                    patternbars = patternbars.Substring(1);
                    patternspaces = patternspaces.Substring(1);
                }//while

                foreach (char c1 in patternmixed)
                {
                    if (bars)
                    {
                        if (c1 == 'N')
                            result += "1";
                        else
                            result += "11";
                    }//if
                    else
                    {
                        if (c1 == 'N')
                            result += "0";
                        else
                            result += "00";
                    }//else
                    bars = !bars;
                }//foreach

            }//foreach

            //add ending bars
            result += "1101";
            Encoded_Value = result;
        }//Encode_Interleaved2of5
        /// <summary>
        /// Encode the raw data using the Standard 2 of 5 algorithm.
        /// </summary>
        private void Encode_Standard2of5()
        {
            if (!CheckNumericOnly(Raw_Data))
                throw new Exception("ES25-1: Numeric Data Only");

            string result = "11011010";

            foreach (char c in Raw_Data)
            {
                result += S25_Code[Int32.Parse(c.ToString())];
            }//foreach

            //add ending bars
            result += "1101011";
            Encoded_Value = result;
        }//Encode_Standard2of5
        /// <summary>
        /// Encode the raw data using the Industrial 2 of 5 algorithm (Same as Standard 2 of 5).
        /// </summary>
        private void Encode_Industrial2of5()
        {
            //Same as Standard 2 of 5
            Encode_Standard2of5();
        }//Encode_Industrial2of5
        /// <summary>
        /// Encode the raw data using the Code 39 algorithm.
        /// </summary>
        private void Encode_Code39()
        {
            this.init_Code39();
            string result = C39_Code['*'].ToString();
            result += "0";//whitespace
            foreach (char c in Raw_Data)
            {
                result += C39_Code[c].ToString();
                result += "0";//whitespace
            }//foreach

            result += C39_Code['*'].ToString();

            //clear the hashtable so it no longer takes up memory
            this.C39_Code.Clear();

            Encoded_Value = result;
        }//Encode_Code39
        /// <summary>
        /// Encode the raw data using the Codabar algorithm.
        /// </summary>
        private void Encode_Codabar()
        {
            if (Raw_Data.Length < 2) throw new Exception("ECODABAR-1: Data format invalid. (Invalid length)");

            //check first char to make sure its a start/stop char
            switch (Raw_Data[0].ToString().ToUpper().Trim())
            {
                case "A": break;
                case "B": break;
                case "C": break;
                case "D": break;
                default: throw new Exception("ECODABAR-2: Data format invalid. (Invalid START character)");
            }//switch

            //check the ending char to make sure its a start/stop char
            switch (Raw_Data[Raw_Data.Trim().Length - 1].ToString().ToUpper().Trim())
            {
                case "A": break;
                case "B": break;
                case "C": break;
                case "D": break;
                default: throw new Exception("ECODABAR-3: Data format invalid. (Invalid STOP character)");
            }//switch

            string result = "";

            //populate the hashtable to begin the process
            this.init_Codabar();

            foreach (char c in Raw_Data)
            {
                result += Codabar_Code[c].ToString();
                result += "0"; //inter-character space
            }//foreach

            //remove the extra 0 at the end of the result
            result = result.Remove(result.Length - 1);

            //clears the hashtable so it no longer takes up memory
            this.Codabar_Code.Clear();

            Encoded_Value = result;
        }//Encode_Codabar
        /// <summary>
        /// Encode the raw data using the PostNet algorithm.
        /// </summary>
        private void Encode_PostNet()
        {
            //remove dashes if present
            Raw_Data = Raw_Data.Replace("-", "");

            switch (Raw_Data.Length)
            {
                case 5:
                case 9:
                case 11: break;
                default: throw new Exception("EPOSTNET-2: Invalid data length. (5, 9, or 11 digits only)");
            }//switch

            //Note: 0 = half bar and 1 = full bar
            //initialize the result with the starting bar
            string result = "1";
            int checkdigitsum = 0;

            foreach (char c in Raw_Data)
            {
                try
                {
                    int index = Convert.ToInt32(c.ToString());
                    result += POSTNET_Code[index];
                    checkdigitsum += index;
                }//try
                catch (Exception ex)
                {
                    throw new Exception("EPOSTNET-2: Invalid data. (Numeric only) --> " + ex.Message);
                }//catch
            }//foreach

            //calculate and add check digit
            result += POSTNET_Code[10 - (checkdigitsum % 10)];

            //ending bar
            result += "1";

            Encoded_Value = result;
        }//Encode_PostNet
        /// <summary>
        /// Encode the raw data using the Bookland/ISBN algorithm.
        /// </summary>
        private void Encode_ISBN_Bookland()
        {
            if (!CheckNumericOnly(Raw_Data))
                throw new Exception("EBOOKLANDISBN-1: Numeric Data Only");

            string type = "UNKNOWN";
            if (Raw_Data.Length == 10 || Raw_Data.Length == 9)
            {
                if (Raw_Data.Length == 10) Raw_Data = Raw_Data.Remove(9, 1);
                Raw_Data = "978" + Raw_Data;
                type = "ISBN";
            }//if
            else if (Raw_Data.Length == 12 && Raw_Data.StartsWith("978"))
            {
                type = "BOOKLAND-NOCHECKDIGIT";
            }//else if
            else if (Raw_Data.Length == 13 && Raw_Data.StartsWith("978"))
            {
                type = "BOOKLAND-CHECKDIGIT";
                Raw_Data = Raw_Data.Remove(12, 1);
            }//else if

            //check to see if its an unknown type
            if (type == "UNKNOWN") throw new Exception("EBOOKLANDISBN-2: Invalid input.");

            Encode_EAN13();
        }//Encode_ISBN_Bookland
        /// <summary>
        /// Encode the raw data using the MSI algorithm.
        /// </summary>
        private void Encode_MSI()
        {
            //check for non-numeric chars
            if (!CheckNumericOnly(Raw_Data))
                throw new Exception("EMSI-1: Numeric Data Only");

            string PreEncoded = Raw_Data;

            //get checksum
            if (Encoded_Type == TYPE.MSI_Mod10 || Encoded_Type == TYPE.MSI_2Mod10)
            {
                string odds = "";
                string evens = "";
                for (int i = PreEncoded.Length - 1; i >= 0; i -= 2)
                {
                    odds = PreEncoded[i].ToString() + odds;
                    if (i - 1 >= 0)
                        evens = PreEncoded[i - 1].ToString() + evens;
                }//for

                //multiply odds by 2
                odds = Convert.ToString((Int32.Parse(odds) * 2));

                int evensum = 0;
                int oddsum = 0;
                foreach (char c in evens)
                    evensum += Int32.Parse(c.ToString());
                foreach (char c in odds)
                    oddsum += Int32.Parse(c.ToString());
                int checksum = 10 - ((oddsum + evensum) % 10);
                PreEncoded += checksum.ToString();
            }//if

            if (Encoded_Type == TYPE.MSI_Mod11 || Encoded_Type == TYPE.MSI_Mod11_Mod10)
            {
                int sum = 0;
                int weight = 2;
                for (int i = PreEncoded.Length - 1; i >= 0; i--)
                {
                    if (weight > 7) weight = 2;
                    sum += Int32.Parse(PreEncoded[i].ToString()) * weight++;
                }//foreach
                int checksum = 11 - (sum % 11);

                PreEncoded += checksum.ToString();
            }//else

            if (Encoded_Type == TYPE.MSI_2Mod10 || Encoded_Type == TYPE.MSI_Mod11_Mod10)
            {
                //get second check digit if 2 mod 10 was selected or Mod11/Mod10
                string odds = "";
                string evens = "";
                for (int i = PreEncoded.Length - 1; i >= 0; i -= 2)
                {
                    odds = PreEncoded[i].ToString() + odds;
                    if (i - 1 >= 0)
                        evens = PreEncoded[i - 1].ToString() + evens;
                }//for

                //multiply odds by 2
                odds = Convert.ToString((Int32.Parse(odds) * 2));

                int evensum = 0;
                int oddsum = 0;
                foreach (char c in evens)
                    evensum += Int32.Parse(c.ToString());
                foreach (char c in odds)
                    oddsum += Int32.Parse(c.ToString());
                int checksum = 10 - ((oddsum + evensum) % 10);
                PreEncoded += checksum.ToString();
            }//if

            string result = "110";
            foreach (char c in PreEncoded)
            {
                result += MSI_Code[Int32.Parse(c.ToString())];
            }//foreach

            //add stop character
            result += "1001";

            Encoded_Value = result;
        }//Encode_MSI
        /// <summary>
        /// Encode the raw data using the Code 11 algorithm.
        /// </summary>
        private void Encode_Code11()
        {
            if (!CheckNumericOnly(Raw_Data.Replace("-", "")))
                throw new Exception("EC11-1: Numeric data and '-' Only");

            //calculate the checksums
            int weight = 1;
            int CTotal = 0;
            string Data_To_Encode_with_Checksums = Raw_Data;

            //figure the C checksum
            for (int i = Raw_Data.Length - 1; i >= 0; i--)
            {
                //C checksum weights go 1-10
                if (weight == 10) weight = 1;

                if (Raw_Data[i] != '-')
                    CTotal += Int32.Parse(Raw_Data[i].ToString()) * weight++;
                else
                    CTotal += 10 * weight++;
            }//for
            int checksumC = CTotal % 11;

            Data_To_Encode_with_Checksums += checksumC.ToString();

            //K checksums are recommended on any message length greater than or equal to 10
            if (Raw_Data.Length >= 1)
            {
                weight = 1;
                int KTotal = 0;

                //calculate K checksum
                for (int i = Data_To_Encode_with_Checksums.Length - 1; i >= 0; i--)
                {
                    //K checksum weights go 1-9
                    if (weight == 9) weight = 1;

                    if (Data_To_Encode_with_Checksums[i] != '-')
                        KTotal += Int32.Parse(Data_To_Encode_with_Checksums[i].ToString()) * weight++;
                    else
                        KTotal += 10 * weight++;
                }//for
                int checksumK = KTotal % 11;
                Data_To_Encode_with_Checksums += checksumK.ToString();
            }//if

            //encode data
            string space = "0";
            string result = C11_Code[11] + space; //start-stop char + interchar space

            foreach (char c in Data_To_Encode_with_Checksums)
            {
                int index = (c == '-' ? 10 : Int32.Parse(c.ToString()));
                result += C11_Code[index];

                //inter-character space
                result += space;
            }//foreach

            //stop bars
            result += C11_Code[11];

            Encoded_Value = result;
        }//Encode_Code11 
        #endregion

        #region Symbologies Not Implemented (Yet)
        private void Encode_Code128()
        {
            //initialize datastructure to hold encoding information
            this.init_Code128();

            string temp = "";
            System.Collections.Queue qData = new Queue();

            #region Break up data for encoding
            //break up the data for encoding
            foreach (char c in Raw_Data)
            {
                if(Char.IsNumber(c)) 
                {
                    if (temp == "")
                    {
                        temp += c;
                    }//if
                    else
                    {
                        temp += c;
                        qData.Enqueue(temp);
                        temp = "";
                    }//else
                }//if
                else 
                {
                    if (temp != "")
                    {
                        qData.Enqueue(temp);
                        temp = "";
                    }//if
                    qData.Enqueue(c);
                }//else
            }//foreach

            //if something is still in temp go ahead and push it onto the queue
            if (temp != "")
            {
                qData.Enqueue(temp);
                temp = "";
            }//if
            #endregion

            throw new Exception("Method not yet implemented. (Encode_Code128)");
        }//Encode_Code128
        private void Encode_Code93()
        {
            throw new Exception("Method not yet implemented. (Encode_Code93)");
        }//Encode_Code93
        #endregion

        #region Image Functions
        /// <summary>
        /// Gets a bitmap representation of the encoded data.
        /// </summary>
        /// <returns>Bitmap of encoded value.</returns>
        private Bitmap Generate_Image()
        {
            return Generate_Image(this.ForeColor, this.BackColor);
        }//Generate_Image()
        /// <summary>
        /// Gets a bitmap representation of the encoded data.
        /// </summary>
        /// <param name="DrawColor">Color to draw the bars.</param>
        /// <param name="BackColor">Color to draw the spaces.</param>
        /// <returns>Bitmap of encoded value.</returns>
        private Bitmap Generate_Image(Color DrawColor, Color BackColor)
        {
            if (Encoded_Value == "") throw new Exception("EGENERATE_IMAGE-1: Must be encoded first.");
            Bitmap b = null;

            switch(this.Encoded_Type)
            {
                case TYPE.UPCA:
                case TYPE.EAN13:
                case TYPE.EAN8:
                case TYPE.Standard2of5:
                case TYPE.Industrial2of5:
                case TYPE.Interleaved2of5:
                case TYPE.CODE11:
                case TYPE.CODE39:
                case TYPE.LOGMARS:
                case TYPE.Codabar:
                case TYPE.BOOKLAND:
                case TYPE.ISBN:
                case TYPE.UPC_SUPPLEMENTAL_2DIGIT:
                case TYPE.UPC_SUPPLEMENTAL_5DIGIT:
                case TYPE.JAN13:
                case TYPE.MSI_Mod10:
                case TYPE.MSI_2Mod10:
                case TYPE.MSI_Mod11:
                case TYPE.UPCE:
                case TYPE.USD8:
                case TYPE.UCC12:
                case TYPE.UCC13:
                    {
                        b = new Bitmap(Encoded_Value.Length * 2, Encoded_Value.Length);
                        //draw image
                        int x = 0;
                        Color c = DrawColor;

                        x = 0;
                        int pos = 0;
                        while (x < b.Width)
                        {
                            if (pos < Encoded_Value.Length)
                            {
                                if (Encoded_Value[pos] == '1')
                                    c = DrawColor;
                                if (Encoded_Value[pos] == '0')
                                    c = BackColor;
                            }//if

                            using (Graphics g = Graphics.FromImage(b))
                            {
                                g.DrawLine(new Pen(c), x, 0, x, b.Height);
                                g.DrawLine(new Pen(c), x + 1, 0, x + 1, b.Height);
                            }//using
                            
                            x += 2;
                            pos++;
                        }//while
                        break;
                    }//case
                case TYPE.PostNet:
                    {
                        b = new Bitmap(Encoded_Value.Length * 4, 20);

                        //draw image
                        for (int y = b.Height-1; y > 0; y--)
                        {
                            int x = 0;
                            if (y < b.Height / 2)
                            { 
                                //top
                                while (x < b.Width)
                                {
                                    if (Encoded_Value[x/4] == '1')
                                    {
                                        //draw bar
                                        b.SetPixel(x, y, DrawColor);
                                        b.SetPixel(x + 1, y, DrawColor);
                                        b.SetPixel(x + 2, y, BackColor);
                                        b.SetPixel(x + 3, y, BackColor);
                                    }//if
                                    else
                                    { 
                                        //draw space
                                        b.SetPixel(x, y, BackColor);
                                        b.SetPixel(x + 1, y, BackColor);
                                        b.SetPixel(x + 2, y, BackColor);
                                        b.SetPixel(x + 3, y, BackColor);
                                    }//else
                                    x += 4;
                                }//while
                            }//if
                            else
                            { 
                               //bottom
                               while (x < b.Width)
                               {
                                    b.SetPixel(x, y, DrawColor);
                                    b.SetPixel(x + 1, y, DrawColor);
                                    b.SetPixel(x + 2, y, BackColor);
                                    b.SetPixel(x + 3, y, BackColor);
                                    x += 4;
                               }//while
                            }//else
                                    
                        }//for

                        break;
                    }//case
                default: return null;
            }//switch

            Encoded_Image = (Image)b;
            bEncoded = true;

            return b;
        }//Generate_Image
        /// <summary>
        /// Resizes the image to a defined width and height.
        /// </summary>
        /// <param name="img">Image to resize.</param>
        /// <param name="nWidth">New width.</param>
        /// <param name="nHeight">New height.</param>
        /// <returns>Resized image.</returns>
        private Image ResizeImage(Image img, int nWidth, int nHeight)
        {
            Bitmap result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((Image)result))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.DrawImage(img, 0, 0, nWidth, nHeight);
            }//using
            return (Image)result;
        }//ResizeImage
        /// <summary>
        /// Resizes an image to a defined percentage of the original size.
        /// </summary>
        /// <param name="img">Image to resize.</param>
        /// <param name="percent">Percent of original size to resize to.</param>
        /// <returns>Resized image.</returns>
        private Image ResizeImage(Image img, double percent)
        {
            return ResizeImage(img, Convert.ToInt32(((double)(percent / (double)100)) * (double)img.Width), Convert.ToInt32(((double)(percent / (double)100)) * img.Height));
        }//ResizeImage
        /// <summary>
        /// Saves an encoded image to a specified file and type.
        /// </summary>
        /// <param name="Filename">Filename to save to.</param>
        /// <param name="FileType">File format to use.</param>
        public void SaveImage(string Filename, SaveTypes FileType)
        {
            try
            {
                if (Encoded_Image != null)
                {
                    System.Drawing.Imaging.ImageFormat imageformat;
                    switch (FileType)
                    {
                        case SaveTypes.BMP: imageformat = System.Drawing.Imaging.ImageFormat.Bmp; break;
                        case SaveTypes.GIF: imageformat = System.Drawing.Imaging.ImageFormat.Gif; break;
                        case SaveTypes.JPG: imageformat = System.Drawing.Imaging.ImageFormat.Jpeg; break;
                        case SaveTypes.PNG: imageformat = System.Drawing.Imaging.ImageFormat.Png; break;
                        case SaveTypes.TIFF: imageformat = System.Drawing.Imaging.ImageFormat.Tiff; break;
                        default: imageformat = System.Drawing.Imaging.ImageFormat.Bmp; break;
                    }//switch
                    ((Bitmap)Encoded_Image).Save(Filename, imageformat);
                }//if
            }//try
            catch(Exception ex)
            {
                throw new Exception("ESAVEIMAGE-1: Could not save image.\n\n=======================\n\n" + ex.Message);
            }//catch
        }//SaveImage(string, SaveTypes)
        #endregion
        #endregion

        #region Label Generation (STILL IN PROGRESS)
        public Image Generate_Labels(Image img)
        {
            if (bEncoded)
            {
                switch (this.Encoded_Type)
                {
                    case TYPE.UPCA: return Label_UPCA(img);
                    default: throw new Exception("EGENERATE_LABELS-1: Invalid type.");
                }//switch
            }//if
            else
                throw new Exception("EGENERATE_LABELS-2: Encode the image first.");
        }//Generate_Labels
        private Image Label_UPCA(Image img)
        {
            System.Drawing.Font font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            
            Graphics g = Graphics.FromImage(img);

            g.DrawImage(img, (float)0, (float)0);

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;

            //draw boxes
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(img.Width/16, img.Height-12, (int)(img.Width * 0.42), img.Height / 2));
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle((int)(img.Width * 0.52), img.Height - 12, (int)(img.Width * 0.42), img.Height / 2));

            string drawstring1 = "";
            string drawstring2 = "";
            foreach (char c in Raw_Data.Substring(1, 5))
            {
                drawstring1 += c.ToString() + "  ";
            }//foreach
            foreach (char c in Raw_Data.Substring(6, 5))
            {
                drawstring2 += c.ToString() + "  ";
            }//foreach

            drawstring1 = drawstring1.Substring(0, drawstring1.Length - 1);
            drawstring2 = drawstring2.Substring(0, drawstring2.Length - 1);
            g.DrawString(drawstring1, font, new SolidBrush(this.ForeColor), new Rectangle(img.Width / 14, img.Height - 13, (int)(img.Width * 0.50), img.Height / 2));
            g.DrawString(drawstring2, font, new SolidBrush(this.ForeColor), new Rectangle((int)(img.Width * 0.55), img.Height - 13, (int)(img.Width * 0.50), img.Height / 2));
            g.Save();
            g.Dispose();

            Bitmap borderincluded = new Bitmap((int)(img.Width * 1.12), (int)(img.Height * 1.12));
            for (int y = 0; y < borderincluded.Height; y++)
                for (int x = 0; x < borderincluded.Width; x++)
                    borderincluded.SetPixel(x, y, Color.White);

            Graphics g2 = Graphics.FromImage((Image)borderincluded);

            g2.SmoothingMode = SmoothingMode.HighQuality;
            g2.InterpolationMode = InterpolationMode.NearestNeighbor;
            g2.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g2.CompositingQuality = CompositingQuality.HighQuality;
                    
            g2.DrawImage((Image)img, (float)((float)img.Width * 0.06), (float)((float)img.Height * 0.06), (float)img.Width, (float)img.Height);

            //UPC-A check digit and number system chars are a little smaller than the other numbers
            font = new Font("MS Sans Serif", 9, FontStyle.Regular);

            //draw the number system digit
            g2.DrawString(Raw_Data[0].ToString(), font, new SolidBrush(this.ForeColor), new Rectangle(-1, img.Height + (int)(img.Height * 0.07) - 13, (int)(img.Width * 0.35), img.Height / 2));

            //draw the check digit
            g2.DrawString(Raw_Data[Raw_Data.Length-1].ToString(), font, new SolidBrush(this.ForeColor), new Rectangle((int)(borderincluded.Width * 0.96), img.Height + (int)(img.Height * 0.07) - 13, (int)(img.Width * 0.35), img.Height / 2));

            g2.Save();
            g2.Dispose();

            this.Encoded_Image = (Image)borderincluded;

            return (Image)borderincluded;
        }//Label_UPCA
        #endregion

        #region Initialization Functions
        private void init_Code39()
        {
            C39_Code.Clear();
            C39_Code.Add('0', "101001101101");
            C39_Code.Add('1', "110100101011");
            C39_Code.Add('2', "101100101011");
            C39_Code.Add('3', "110110010101");
            C39_Code.Add('4', "101001101011");
            C39_Code.Add('5', "110100110101");
            C39_Code.Add('6', "101100110101");
            C39_Code.Add('7', "101001011011");
            C39_Code.Add('8', "110100101101");
            C39_Code.Add('9', "101100101101");
            C39_Code.Add('A', "110101001011");
            C39_Code.Add('B', "101101001011");
            C39_Code.Add('C', "110110100101");
            C39_Code.Add('D', "101011001011");
            C39_Code.Add('E', "110101100101");
            C39_Code.Add('F', "101101100101");
            C39_Code.Add('G', "101010011011");
            C39_Code.Add('H', "110101001101");
            C39_Code.Add('I', "101101001101");
            C39_Code.Add('J', "101011001101");
            C39_Code.Add('K', "110101010011");
            C39_Code.Add('L', "101101010011");
            C39_Code.Add('M', "110110101001");
            C39_Code.Add('N', "101011010011");
            C39_Code.Add('O', "110101101001");
            C39_Code.Add('P', "101101101001");
            C39_Code.Add('Q', "101010110011");
            C39_Code.Add('R', "110101011001");
            C39_Code.Add('S', "101101011001");
            C39_Code.Add('T', "101011011001");
            C39_Code.Add('U', "110010101011");
            C39_Code.Add('V', "100110101011");
            C39_Code.Add('W', "110011010101");
            C39_Code.Add('X', "100101101011");
            C39_Code.Add('Y', "110010110101");
            C39_Code.Add('Z', "100110110101");
            C39_Code.Add('-', "100101011011");
            C39_Code.Add('.', "110010101101");
            C39_Code.Add(' ', "100110101101");
            C39_Code.Add('$', "100100100101");
            C39_Code.Add('/', "100100101001");
            C39_Code.Add('+', "100101001001");
            C39_Code.Add('%', "101001001001");
            C39_Code.Add('*', "100101101101");
        }//init_Code39
        private void init_Codabar()
        {
            Codabar_Code.Clear();
            Codabar_Code.Add('0', "101010011");//"101001101101");
            Codabar_Code.Add('1', "101011001");//"110100101011");
            Codabar_Code.Add('2', "101001011");//"101100101011");
            Codabar_Code.Add('3', "110010101");//"110110010101");
            Codabar_Code.Add('4', "101101001");//"101001101011");
            Codabar_Code.Add('5', "110101001");//"110100110101");
            Codabar_Code.Add('6', "100101011");//"101100110101");
            Codabar_Code.Add('7', "100101101");//"101001011011");
            Codabar_Code.Add('8', "100110101");//"110100101101");
            Codabar_Code.Add('9', "110100101");//"101100101101");
            Codabar_Code.Add('-', "101001101");//"110101001011");
            Codabar_Code.Add('$', "101100101");//"101101001011");
            Codabar_Code.Add(':', "1101011011");//"110110100101");
            Codabar_Code.Add('/', "1101101011");//"101011001011");
            Codabar_Code.Add('.', "1101101101");//"110101100101");
            Codabar_Code.Add('+', "101100110011");//"101101100101");
            Codabar_Code.Add('A', "1011001001");//"110110100101");
            Codabar_Code.Add('B', "1010010011");//"101011001011");
            Codabar_Code.Add('C', "1001001011");//"110101100101");
            Codabar_Code.Add('D', "1010011001");//"101101100101");
            Codabar_Code.Add('a', "1011001001");//"110110100101");
            Codabar_Code.Add('b', "1010010011");//"101011001011");
            Codabar_Code.Add('c', "1001001011");//"110101100101");
            Codabar_Code.Add('d', "1010011001");//"101101100101");
        }//init_Codeabar
        private void init_CountryCodes()
        {
            CountryCodes.Clear();
            CountryCodes.Add("00", "US / CANADA");
            CountryCodes.Add("01", "US / CANADA");
            CountryCodes.Add("02", "US / CANADA");
            CountryCodes.Add("03", "US / CANADA");
            CountryCodes.Add("04", "US / CANADA");
            CountryCodes.Add("05", "US / CANADA");
            CountryCodes.Add("06", "US / CANADA");
            CountryCodes.Add("07", "US / CANADA");
            CountryCodes.Add("08", "US / CANADA");
            CountryCodes.Add("09", "US / CANADA");
            CountryCodes.Add("10", "US / CANADA");
            CountryCodes.Add("11", "US / CANADA");
            CountryCodes.Add("12", "US / CANADA");
            CountryCodes.Add("13", "US / CANADA");

            CountryCodes.Add("20", "IN STORE");
            CountryCodes.Add("21", "IN STORE");
            CountryCodes.Add("22", "IN STORE");
            CountryCodes.Add("23", "IN STORE");
            CountryCodes.Add("24", "IN STORE");
            CountryCodes.Add("25", "IN STORE");
            CountryCodes.Add("26", "IN STORE");
            CountryCodes.Add("27", "IN STORE");
            CountryCodes.Add("28", "IN STORE");
            CountryCodes.Add("29", "IN STORE");

            CountryCodes.Add("30", "FRANCE");
            CountryCodes.Add("31", "FRANCE");
            CountryCodes.Add("32", "FRANCE");
            CountryCodes.Add("33", "FRANCE");
            CountryCodes.Add("34", "FRANCE");
            CountryCodes.Add("35", "FRANCE");
            CountryCodes.Add("36", "FRANCE");
            CountryCodes.Add("37", "FRANCE");

            CountryCodes.Add("40", "GERMANY");
            CountryCodes.Add("41", "GERMANY");
            CountryCodes.Add("42", "GERMANY");
            CountryCodes.Add("43", "GERMANY");
            CountryCodes.Add("44", "GERMANY");

            CountryCodes.Add("45", "JAPAN");
            CountryCodes.Add("46", "RUSSIAN FEDERATION");
            CountryCodes.Add("49", "JAPAN (JAN-13)");

            CountryCodes.Add("50", "UNITED KINGDOM");
            CountryCodes.Add("54", "BELGIUM / LUXEMBOURG");
            CountryCodes.Add("57", "DENMARK");

            CountryCodes.Add("64", "FINLAND");

            CountryCodes.Add("70", "NORWAY");
            CountryCodes.Add("73", "SWEDEN");
            CountryCodes.Add("76", "SWITZERLAND");

            CountryCodes.Add("80", "ITALY");
            CountryCodes.Add("81", "ITALY");
            CountryCodes.Add("82", "ITALY");
            CountryCodes.Add("83", "ITALY");
            CountryCodes.Add("84", "SPAIN");
            CountryCodes.Add("87", "NETHERLANDS");

            CountryCodes.Add("90", "AUSTRIA");
            CountryCodes.Add("91", "AUSTRIA");
            CountryCodes.Add("93", "AUSTRALIA");
            CountryCodes.Add("94", "NEW ZEALAND");
            CountryCodes.Add("99", "COUPONS");

            CountryCodes.Add("471", "TAIWAN");
            CountryCodes.Add("474", "ESTONIA");
            CountryCodes.Add("475", "LATVIA");
            CountryCodes.Add("477", "LITHUANIA");
            CountryCodes.Add("479", "SRI LANKA");
            CountryCodes.Add("480", "PHILIPPINES");
            CountryCodes.Add("482", "UKRAINE");
            CountryCodes.Add("484", "MOLDOVA");
            CountryCodes.Add("485", "ARMENIA");
            CountryCodes.Add("486", "GEORGIA");
            CountryCodes.Add("487", "KAZAKHSTAN");
            CountryCodes.Add("489", "HONG KONG");

            CountryCodes.Add("520", "GREECE");
            CountryCodes.Add("528", "LEBANON");
            CountryCodes.Add("529", "CYPRUS");
            CountryCodes.Add("531", "MACEDONIA");
            CountryCodes.Add("535", "MALTA");
            CountryCodes.Add("539", "IRELAND");
            CountryCodes.Add("560", "PORTUGAL");
            CountryCodes.Add("569", "ICELAND");
            CountryCodes.Add("590", "POLAND");
            CountryCodes.Add("594", "ROMANIA");
            CountryCodes.Add("599", "HUNGARY");
            
            CountryCodes.Add("600", "SOUTH AFRICA");
            CountryCodes.Add("601", "SOUTH AFRICA");
            CountryCodes.Add("609", "MAURITIUS");
            CountryCodes.Add("611", "MOROCCO");
            CountryCodes.Add("613", "ALGERIA");
            CountryCodes.Add("619", "TUNISIA");
            CountryCodes.Add("622", "EGYPT");
            CountryCodes.Add("625", "JORDAN");
            CountryCodes.Add("626", "IRAN");
            CountryCodes.Add("690", "CHINA");
            CountryCodes.Add("691", "CHINA");
            CountryCodes.Add("692", "CHINA");

            CountryCodes.Add("729", "ISRAEL");
            CountryCodes.Add("740", "GUATEMALA");
            CountryCodes.Add("741", "EL SALVADOR");
            CountryCodes.Add("742", "HONDURAS");
            CountryCodes.Add("743", "NICARAGUA");
            CountryCodes.Add("744", "COSTA RICA");
            CountryCodes.Add("746", "DOMINICAN REPUBLIC");
            CountryCodes.Add("750", "MEXICO");
            CountryCodes.Add("759", "VENEZUELA");
            CountryCodes.Add("770", "COLOMBIA");
            CountryCodes.Add("773", "URUGUAY");
            CountryCodes.Add("775", "PERU");
            CountryCodes.Add("777", "BOLIVIA");
            CountryCodes.Add("779", "ARGENTINA");
            CountryCodes.Add("780", "CHILE");
            CountryCodes.Add("784", "PARAGUAY");
            CountryCodes.Add("785", "PERU");
            CountryCodes.Add("786", "ECUADOR");
            CountryCodes.Add("789", "BRAZIL");

            CountryCodes.Add("850", "CUBA");
            CountryCodes.Add("858", "SLOVAKIA");
            CountryCodes.Add("859", "CZECH REPUBLIC");
            CountryCodes.Add("860", "YUGLOSLAVIA");
            CountryCodes.Add("869", "TURKEY");
            CountryCodes.Add("880", "SOUTH KOREA");
            CountryCodes.Add("885", "THAILAND");
            CountryCodes.Add("888", "SINGAPORE");
            CountryCodes.Add("890", "INDIA");
            CountryCodes.Add("893", "VIETNAM");
            CountryCodes.Add("899", "INDONESIA");
              
            CountryCodes.Add("955", "MALAYSIA");
            CountryCodes.Add("977", "INTERNATIONAL STANDARD SERIAL NUMBER FOR PERIODICALS (ISSN)");
            CountryCodes.Add("978", "INTERNATIONAL STANDARD BOOK NUMBERING (ISBN)");
            CountryCodes.Add("979", "INTERNATIONAL STANDARD MUSIC NUMBER (ISMN)");
            CountryCodes.Add("980", "REFUND RECEIPTS");
            CountryCodes.Add("981", "COMMON CURRENCY COUPONS");
            CountryCodes.Add("982", "COMMON CURRENCY COUPONS");
        }//init_CountryCodes
        private void init_Code128()
        {
            //set up columns
            this.C128_Code.Columns.Add("Value", typeof(string));
            this.C128_Code.Columns.Add("A", typeof(string));
            this.C128_Code.Columns.Add("B", typeof(string));
            this.C128_Code.Columns.Add("C", typeof(string));
            this.C128_Code.Columns.Add("Encoding", typeof(string));

            //populate data
            this.C128_Code.Rows.Add(new object[] { "00", "SP", "SP", "00", "11011001100" });
            this.C128_Code.Rows.Add(new object[] { "01", "!" , "!", "01", "11001101100" });
            this.C128_Code.Rows.Add(new object[] { "02", "\"", "\"", "02", "11001100110" });
            this.C128_Code.Rows.Add(new object[] { "03", "#" , "#", "03", "10010011000" });
            this.C128_Code.Rows.Add(new object[] { "04", "$" , "$", "04", "10010001100" });
            this.C128_Code.Rows.Add(new object[] { "05", "%" , "%", "05", "10001001100" });
            this.C128_Code.Rows.Add(new object[] { "06", "&" , "&", "06", "10011001000" });
            this.C128_Code.Rows.Add(new object[] { "07", "'" , "'", "07", "10011000100" });
            this.C128_Code.Rows.Add(new object[] { "08", "(" , ")", "08", "10001100100" });
            this.C128_Code.Rows.Add(new object[] { "09", ")" , ")", "09", "11001001000" });
            this.C128_Code.Rows.Add(new object[] { "10", "*" , "*", "10", "11001000100" });
            this.C128_Code.Rows.Add(new object[] { "11", "+" , "+", "11", "11000100100" });
            this.C128_Code.Rows.Add(new object[] { "12", "," , ",", "12", "10110011100" });
            this.C128_Code.Rows.Add(new object[] { "13", "-" , "-", "13", "10011011100" });
            this.C128_Code.Rows.Add(new object[] { "14", "." , ".", "14", "10011001110" });
            this.C128_Code.Rows.Add(new object[] { "15", "/" , "/", "15", "10111001100" });
            this.C128_Code.Rows.Add(new object[] { "16", "0" , "0", "16", "10011101100" });
            this.C128_Code.Rows.Add(new object[] { "17", "1" , "1", "17", "10011100110" });
            this.C128_Code.Rows.Add(new object[] { "18", "2" , "2", "18", "11001110010" });
            this.C128_Code.Rows.Add(new object[] { "19", "3" , "3", "19", "11001011100" });
            this.C128_Code.Rows.Add(new object[] { "20", "4" , "4", "20", "11001001110" });
            this.C128_Code.Rows.Add(new object[] { "21", "5" , "5", "21", "11011100100" });
            this.C128_Code.Rows.Add(new object[] { "22", "6" , "6", "22", "11001110100" });
            this.C128_Code.Rows.Add(new object[] { "23", "7" , "7", "23", "11101101110" });
            this.C128_Code.Rows.Add(new object[] { "24", "8" , "8", "24", "11101001100" });
            this.C128_Code.Rows.Add(new object[] { "25", "9" , "9", "25", "11100101100" });
            this.C128_Code.Rows.Add(new object[] { "26", ":" , ":", "26", "11100100110" });
            this.C128_Code.Rows.Add(new object[] { "27", ";" , ";", "27", "11101100100" });
            this.C128_Code.Rows.Add(new object[] { "28", "<" , "<", "28", "11100110100" });
            this.C128_Code.Rows.Add(new object[] { "29", "=" , "=", "29", "11100110010" });
            this.C128_Code.Rows.Add(new object[] { "30", ">" , ">", "30", "11011011000" });
            this.C128_Code.Rows.Add(new object[] { "31", "?" , "?", "31", "11011000110" });
            this.C128_Code.Rows.Add(new object[] { "32", "@" , "@", "32", "11000110110" });
            this.C128_Code.Rows.Add(new object[] { "33", "A" , "A", "33", "10100011000" });
            this.C128_Code.Rows.Add(new object[] { "34", "B" , "B", "34", "10001011000" });
            this.C128_Code.Rows.Add(new object[] { "35", "C" , "C", "35", "10001000110" });
            this.C128_Code.Rows.Add(new object[] { "36", "D" , "D", "36", "10110001000" });
            this.C128_Code.Rows.Add(new object[] { "37", "E" , "E", "37", "10001101000" });
            this.C128_Code.Rows.Add(new object[] { "38", "F" , "F", "38", "10001100010" });
            this.C128_Code.Rows.Add(new object[] { "39", "G" , "G", "39", "11010001000" });
            this.C128_Code.Rows.Add(new object[] { "40", "H" , "H", "40", "11000101000" });
            this.C128_Code.Rows.Add(new object[] { "41", "I" , "I", "41", "11000100010" });
            this.C128_Code.Rows.Add(new object[] { "42", "J" , "J", "42", "10110111000" });
            this.C128_Code.Rows.Add(new object[] { "43", "K" , "K", "43", "10110001110" });
            this.C128_Code.Rows.Add(new object[] { "44", "L" , "L", "44", "10001101110" });
            this.C128_Code.Rows.Add(new object[] { "45", "M" , "M", "45", "10111011000" });
            this.C128_Code.Rows.Add(new object[] { "46", "N" , "N", "46", "10111000110" });
            this.C128_Code.Rows.Add(new object[] { "47", "O" , "O", "47", "10001110110" });
            this.C128_Code.Rows.Add(new object[] { "48", "P" , "P", "48", "11101110110" });
            this.C128_Code.Rows.Add(new object[] { "49", "Q" , "Q", "49", "11010001110" });
            this.C128_Code.Rows.Add(new object[] { "50", "R" , "R", "50", "11000101110" });
            this.C128_Code.Rows.Add(new object[] { "51", "S" , "S", "51", "11011101000" });
            this.C128_Code.Rows.Add(new object[] { "52", "T" , "T", "52", "11011100010" });
            this.C128_Code.Rows.Add(new object[] { "53", "U" , "U", "53", "11011101110" });
            this.C128_Code.Rows.Add(new object[] { "54", "V" , "V", "54", "11101011000" });
            this.C128_Code.Rows.Add(new object[] { "55", "W" , "W", "55", "11101000110" });
            this.C128_Code.Rows.Add(new object[] { "56", "X" , "X", "56", "11100010110" });
            this.C128_Code.Rows.Add(new object[] { "57", "Y" , "Y", "57", "11101101000" });
            this.C128_Code.Rows.Add(new object[] { "58", "Z" , "U", "58", "11101100010" });
            this.C128_Code.Rows.Add(new object[] { "59", "[" , "[", "59", "11100011010" });
            this.C128_Code.Rows.Add(new object[] { "60",@"\" ,@"\", "60", "11101111010" });
            this.C128_Code.Rows.Add(new object[] { "61", "]" , "]", "61", "11001000010" });
            this.C128_Code.Rows.Add(new object[] { "62", "^" , "^", "62", "11110001010" });
            this.C128_Code.Rows.Add(new object[] { "63", "_" , "_", "63", "10100110000" });
            this.C128_Code.Rows.Add(new object[] { "64", "\0",  "`", "64", "10100001100" });
            this.C128_Code.Rows.Add(new object[] { "65", "SOH", "a", "65", "10010110000" });
            this.C128_Code.Rows.Add(new object[] { "66", "STX", "b", "66", "10010000110" });
            this.C128_Code.Rows.Add(new object[] { "67", "ETX", "c", "67", "10000101100" });
            this.C128_Code.Rows.Add(new object[] { "68", "EOT", "d", "68", "10000100110" });
            this.C128_Code.Rows.Add(new object[] { "69", "ENQ", "e", "69", "10110010000" });
            this.C128_Code.Rows.Add(new object[] { "70", "ACK", "f", "70", "10110000100" });
            this.C128_Code.Rows.Add(new object[] { "71", "BEL", "g", "71", "10011010000" });
            this.C128_Code.Rows.Add(new object[] { "72", "BS" , "h", "72", "10011000010" });
            this.C128_Code.Rows.Add(new object[] { "73", "HT" , "i", "73", "10000110100" });
            this.C128_Code.Rows.Add(new object[] { "74", "LF" , "j", "74", "10000110010" });
            this.C128_Code.Rows.Add(new object[] { "75", "VT" , "k", "75", "11000010010" });
            this.C128_Code.Rows.Add(new object[] { "76", "FF" , "l", "76", "11001010000" });
            this.C128_Code.Rows.Add(new object[] { "77", "CR" , "m", "77", "11110111010" });
            this.C128_Code.Rows.Add(new object[] { "78", "SO" , "n", "78", "11000010100" });
            this.C128_Code.Rows.Add(new object[] { "79", "SI" , "o", "79", "10001111010" });
            this.C128_Code.Rows.Add(new object[] { "80", "DLE", "p", "80", "10100111100" });
            this.C128_Code.Rows.Add(new object[] { "81", "DC1", "q", "81", "10010111100" });
            this.C128_Code.Rows.Add(new object[] { "82", "DC2", "r", "82", "10010011110" });
            this.C128_Code.Rows.Add(new object[] { "83", "DC3", "s", "83", "10111100100" });
            this.C128_Code.Rows.Add(new object[] { "84", "DC4", "t", "84", "10011110100" });
            this.C128_Code.Rows.Add(new object[] { "85", "NAK", "u", "85", "10011110010" });
            this.C128_Code.Rows.Add(new object[] { "86", "SYN", "v", "86", "11110100100" });
            this.C128_Code.Rows.Add(new object[] { "87", "ETB", "w", "87", "11110010100" });
            this.C128_Code.Rows.Add(new object[] { "88", "CAN", "x", "88", "11110010010" });
            this.C128_Code.Rows.Add(new object[] { "89", "EM" , "y", "89", "11011011110" });
            this.C128_Code.Rows.Add(new object[] { "90", "SUB", "z", "90", "11011110110" });
            this.C128_Code.Rows.Add(new object[] { "91", "ESC", "{", "91", "11110110110" });
            this.C128_Code.Rows.Add(new object[] { "92", "FS" , "|", "92", "10101111000" });
            this.C128_Code.Rows.Add(new object[] { "93", "GS" , "}", "93", "10100011110" });
            this.C128_Code.Rows.Add(new object[] { "94", "RS" , "~", "94", "10001011110" });

            this.C128_Code.Rows.Add(new object[] { "95" , "US"     , "DEL"    , "95"     , "10111101000" });
            this.C128_Code.Rows.Add(new object[] { "96" , "FNC3"   , "FNC3"   , "96"     , "10111100010" });
            this.C128_Code.Rows.Add(new object[] { "97" , "FNC2"   , "FNC2"   , "97"     , "11110101000" });
            this.C128_Code.Rows.Add(new object[] { "98" , "SHIFT"  , "SHIFT"  , "98"     , "11110100010" });
            this.C128_Code.Rows.Add(new object[] { "99" , "CODE_C" , "CODE_C" , "99"     , "10111011110" });
            this.C128_Code.Rows.Add(new object[] { "100", "CODE_B" , "FNC4"   , "CODE_B" , "10111101110" });
            this.C128_Code.Rows.Add(new object[] { "101", "FNC4"   , "CODE_A" , "CODE_A" , "11101011110" });
            this.C128_Code.Rows.Add(new object[] { "102", "FNC1"   , "FNC1"   , "FNC1"   , "11110101110" });
            this.C128_Code.Rows.Add(new object[] { "103", "START_A", "START_A", "START_A", "11010000100" });
            this.C128_Code.Rows.Add(new object[] { "104", "START_B", "START_B", "START_B", "11010010000" });
            this.C128_Code.Rows.Add(new object[] { "105", "START_C", "START_C", "START_C", "11010011100" });
            this.C128_Code.Rows.Add(new object[] { ""   , "STOP"   , "STOP"   , "STOP"   , "11000111010" });
        }//init_Code128
        #endregion

        #region Misc
        private bool CheckNumericOnly(string Data)
        {
            try
            {
                int test = 0;
                foreach (char c in Data)
                    test = Convert.ToInt32(c.ToString());
                return true;
            }//try
            catch
            {
                return false;
            }//catch
        }//CheckNumericOnly
        #endregion

        #region Static Methods
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <returns>Image representing the barcode.</returns>
        public static Image DoEncode(TYPE iType, string data)
        {
            Barcode b = new Barcode();
            b.Encode(iType, data);
            return b.Generate_Image();
        }
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="percent">Percentage of the original size to size the result.</param>
        /// <returns>Image representing the barcode.</returns>
        public static Image DoEncode(TYPE iType, string data, double percent)
        {
            Barcode b = new Barcode();
            b.Encode(iType, data, percent);
            return b.Generate_Image();
        }
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <returns>Image representing the barcode.</returns>
        public static Image DoEncode(TYPE iType, string data, int Width, int Height)
        {
            Barcode b = new Barcode();
            b.Encode(iType, data, Width, Height);
            return b.Generate_Image();
        }
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <returns>Image representing the barcode.</returns>
        public static Image DoEncode(TYPE iType, string data, Color DrawColor, Color BackColor)
        {
            Barcode b = new Barcode();
            b.Encode(iType, data, DrawColor, BackColor);
            return b.Generate_Image();
        }
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <returns>Image representing the barcode.</returns>
        public static Image DoEncode(TYPE iType, string data, Color DrawColor, Color BackColor, int Width, int Height)
        {
            Barcode b = new Barcode();
            b.Encode(iType, data, DrawColor, BackColor, Width, Height);
            return b.Generate_Image();
        }
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <param name="percent">Percentage of the original size to size the result.</param>
        /// <returns></returns>
        public static Image DoEncode(TYPE iType, string data, Color DrawColor, Color BackColor, double percent)
        {
            Barcode b = new Barcode();
            b.Encode(iType, data, DrawColor, BackColor, percent);
            return b.Generate_Image();
        }        
        #endregion
    }//Barcode Class
}//Barcode namespace
