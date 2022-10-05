using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Model
{
    internal interface ISauvergardeXML
    {
        public XmlNode toXMl(XmlDocument doc);

    }
}
