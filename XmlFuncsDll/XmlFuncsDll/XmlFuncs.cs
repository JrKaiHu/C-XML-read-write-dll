using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using System.Xml.Linq;
using System.Xml.XPath;

namespace XmlFunctions
{
    #region Error Code

    public enum XMLErrorCode
    {
        SUCCESS,
        INVALID_XML_FILE_PATH,
        INVALID_XML_PATH,
        INVALID_PARAMETER_TYPE
    }

    #endregion

    public class XmlFuncs
    {
        private static readonly XmlFuncs _instance = new XmlFuncs();
        private XmlFuncs() { }
        public static XmlFuncs Instance { get { return _instance; } }

        private string m_strOutput = "";


        #region Get Xml data

        private XMLErrorCode GetXmlDataFunc(string strXmlFilePath, string strXmlPath, string strValName, ref string strOutput)
        {
            try
            {
                XDocument doc = XDocument.Load(strXmlFilePath);

                try
                {
                    strOutput = doc.XPathSelectElement(strXmlPath + "/" + strValName).Value;
                    return XMLErrorCode.SUCCESS;
                }
                catch
                {
                    try
                    {
                        strOutput = doc.XPathSelectElement(strXmlPath).Attribute(strValName).Value;
                        return XMLErrorCode.SUCCESS;
                    }
                    catch
                    {
                        strOutput = "";
                        return XMLErrorCode.INVALID_XML_PATH;
                    }                    
                }
            }
            catch
            {
                return XMLErrorCode.INVALID_XML_FILE_PATH;
            }            
        }

        public static XMLErrorCode GetXmlData(string strXmlFilePath, string strXmlPath, string strValName, ref string strOutput)
        {
            strOutput = "";

            XMLErrorCode nRet = Instance.GetXmlDataFunc(strXmlFilePath, strXmlPath, strValName, ref strOutput);

            return nRet;
        }

        public static XMLErrorCode GetXmlData(string strXmlFilePath, string strXmlPath, string strValName, ref int nOutput)
        {
            nOutput = 0;

            XMLErrorCode nRet = Instance.GetXmlDataFunc(strXmlFilePath, strXmlPath, strValName, ref Instance.m_strOutput);

            if (nRet == XMLErrorCode.SUCCESS)
            {
                try
                {
                    nOutput = Convert.ToInt32(Instance.m_strOutput);
                }
                catch
                {
                    nRet = XMLErrorCode.INVALID_PARAMETER_TYPE;
                }
            }

            return nRet;
        }

        public static XMLErrorCode GetXmlData(string strXmlFilePath, string strXmlPath, string strValName, ref long lOutput)
        {
            lOutput = 0;

            XMLErrorCode nRet = Instance.GetXmlDataFunc(strXmlFilePath, strXmlPath, strValName, ref Instance.m_strOutput);

            if (nRet == XMLErrorCode.SUCCESS)
            {
                try
                {
                    lOutput = Convert.ToInt64(Instance.m_strOutput);
                }
                catch
                {
                    nRet = XMLErrorCode.INVALID_PARAMETER_TYPE;
                }
            }

            return nRet;
        }

        public static XMLErrorCode GetXmlData(string strXmlFilePath, string strXmlPath, string strValName, ref double dOutput)
        {
            dOutput = 0;

            XMLErrorCode nRet = Instance.GetXmlDataFunc(strXmlFilePath, strXmlPath, strValName, ref Instance.m_strOutput);

            if (nRet == XMLErrorCode.SUCCESS)
            {
                try
                {
                    dOutput = Convert.ToDouble(Instance.m_strOutput);
                }
                catch
                {
                    nRet = XMLErrorCode.INVALID_PARAMETER_TYPE;
                }
            }

            return nRet;
        }

        public static XMLErrorCode GetXmlData(string strXmlFilePath, string strXmlPath, string strValName, ref bool bOutput)
        {
            bOutput = false;

            XMLErrorCode nRet = Instance.GetXmlDataFunc(strXmlFilePath, strXmlPath, strValName, ref Instance.m_strOutput);

            if (nRet == XMLErrorCode.SUCCESS)
            {
                try
                {
                    bOutput = Convert.ToBoolean(Int32.Parse(Instance.m_strOutput));
                }
                catch
                {
                    nRet = XMLErrorCode.INVALID_PARAMETER_TYPE;
                }
            }

            return nRet;
        }

        public static XMLErrorCode GetXmlData(string strXmlFilePath, string strXmlPath, string strValName, ref byte byOutput)
        {
            byOutput = 0;

            XMLErrorCode nRet = Instance.GetXmlDataFunc(strXmlFilePath, strXmlPath, strValName, ref Instance.m_strOutput);

            if (nRet == XMLErrorCode.SUCCESS)
            {
                try
                {
                    byOutput = Convert.ToByte(Instance.m_strOutput);
                }
                catch
                {
                    nRet = XMLErrorCode.INVALID_PARAMETER_TYPE;
                }
            }

            return nRet;
        }

        #endregion
    }
}
