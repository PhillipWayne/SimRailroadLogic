using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLogicRailRoad
{
    public class Choosingtrack
    {
        string[] otherbits = new string[2];
        public string[] whichcomponent(object obj)
        {

            SizeablePictureBox pb = (SizeablePictureBox)obj;
            
            List<string> bitval = new List<string>();
            pb.Tag = (string[])pb.Tag;


            string[] trk = (string[])pb.Tag;

            switch (trk[1])
            {
                case "trk180":

                    if (pb.Bitsofcomponents[2] != null && pb.Bitsofcomponents[2] != "")
                    {
                        if (pb.Bitsofcomponents[2] == "A")
                        {
                            otherbits[0] = "C";
                            otherbits[1] = "E";
                        }
                        else if (pb.Bitsofcomponents[2] == "C")
                        {
                            otherbits[0] = "E";
                            otherbits[1] = "A";
                        }
                        else if (pb.Bitsofcomponents[2] == "E")
                        {
                            otherbits[0] = "C";
                            otherbits[1] = "A";
                        }
                    }
                    
                    break;

            }
            string[] twosignal = (string[])pb.Tag;

            switch (twosignal[1])
            {
                case "TH_W_signal":

                    if (pb.Bitsofcomponents[6] != null && pb.Bitsofcomponents[6] != "")
                    {
                        if (pb.Bitsofcomponents[6] == "A")
                        {
                            otherbits[0] = "C";
                            otherbits[1] = "E";
                        }
                        else if (pb.Bitsofcomponents[6] == "C")
                        {
                            otherbits[0] = "E";
                            otherbits[1] = "A";
                        }
                        else if (pb.Bitsofcomponents[6] == "E")
                        {
                            otherbits[0] = "C";
                            otherbits[1] = "A";
                        }
                    }
                    
                    break;
            }

            string[] onesignal = (string[])pb.Tag;

            switch (onesignal[1])
            {
                case "OH_E_Signal":

                    if (pb.Bitsofcomponents[6] != null && pb.Bitsofcomponents[6] != "")
                    {
                        if (pb.Bitsofcomponents[6] == "A")
                        {
                            otherbits[0] = "C";
                            otherbits[1] = "E";
                        }
                        else if (pb.Bitsofcomponents[6] == "C")
                        {
                            otherbits[0] = "E";
                            otherbits[1] = "A";
                        }
                        else if (pb.Bitsofcomponents[6] == "E")
                        {
                            otherbits[0] = "C";
                            otherbits[1] = "A";
                        }
                    }

                    break;
            }

            string[] switches = (string[])pb.Tag;

            switch (switches[1])
            {
                case "SwitchBL":
                    if (pb.Bitsofcomponents[6] != null && pb.Bitsofcomponents[6] != "")
                    {
                        if (pb.Bitsofcomponents[6] == "A")
                        {
                            otherbits[0] = "C";
                            otherbits[1] = "E";
                        }
                        else if (pb.Bitsofcomponents[6] == "C")
                        {
                            otherbits[0] = "E";
                            otherbits[1] = "A";
                        }
                        else if (pb.Bitsofcomponents[6] == "E")
                        {
                            otherbits[0] = "C";
                            otherbits[1] = "A";
                        }
                    }

                    break;
            }


            return otherbits;
        }
    }
}

