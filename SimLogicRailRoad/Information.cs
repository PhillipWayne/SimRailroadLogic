using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using testsim;

namespace testsim
{

    public class Information
    {

        // This is where the properties of a object are stored 
        // I made use of accessors which allow for the property to be read and write

        private string componentpic; //this is the field 



        [XmlElement("pics")] // This attaches the word pics to all the elements in Trk1.
        public string Componentpic // this is the property and is called between classes 
        {
            get { return componentpic; } // the get is invoked when property of Trk1 is invoked
            // THe get is used to read the field of trk1
            set { componentpic = value; } // The set is invoked when the property is assigned a new value and 
            // that is assigned to the field. This is the write 
        }

        private string piclocx;
        [XmlElement("locx")]
        public string Piclocx
        {
            get { return piclocx; }
            set { piclocx = value; }
        }

        private string piclocy;
        [XmlElement("locy")]
        public string Piclocy
        {
            get { return piclocy; }
            set { piclocy = value; }
        }

        private string[] bitsofcomponents;
        [XmlElement("bitsofcomponents")]
        public string [] Bitsofcomponents 
            {
            get{ return bitsofcomponents ; }
            set{ bitsofcomponents  = value; }
            }

        private string componentname;
        [XmlElement("Componentname")]
        public string Componentname
        {
            get { return componentname; }
            set { componentname = value; }
        }

        
    }
    
}
