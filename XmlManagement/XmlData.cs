using CustomUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XmlManagement
{
    public class XmlData
    {
        XmlDocument? xdoc;
        XmlDirectory? xmlDirectory;
        public string? xmlPath;
        private string? mainSql;
        private Dictionary<string, XmlOptionData>? optionSql;
        Dictionary<string, XmlOptionData>? result;

        public XmlData()
        {
            XmlSync();
        }

        public XmlData(string databaseProvider)
        {
            XmlSync(databaseProvider);
        }
        public XmlData(string databaseProvider, string SystemTypeCode)
        {
            XmlSync(databaseProvider, SystemTypeCode);
        }

        public string MainSql { get => mainSql; set => mainSql = value; }
        public Dictionary<string, XmlOptionData> OptionSql { get => optionSql; set => optionSql = value; }

        public void XmlSync() 
        {
            this.xdoc = new XmlDocument();
            this.xmlDirectory = new XmlDirectory();

            try
            {
                //실행 시 에러가 발생하는 것을 파악하기 위해 개별 파일로 분리함


                DirectoryInfo directoryInfo = new DirectoryInfo(xmlDirectory.OracleSqlDirectory.Trim());
                if (directoryInfo.Exists)
                {
                    result = new Dictionary<string, XmlOptionData>();

                    foreach (FileInfo file in directoryInfo.GetFiles())
                    {
                        
                        XmlNode fileNode = ConvertFileInfoToXmlNode(file);
                        result.Add(fileNode.Name, new XmlOptionData(fileNode));
                    }
                }
                else
                {
                    xdoc.Load(xmlDirectory.OracleSqlDirectory);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void XmlSync(string DatabaseProvider)
        {
            this.xdoc = new XmlDocument();
            this.xmlDirectory = new XmlDirectory();

            try
            {
                //실행 시 에러가 발생하는 것을 파악하기 위해 개별 파일로 분리함
                DirectoryInfo? directoryInfo = null;
                if (DatabaseProvider.Equals("ORACLE"))
                {
                    directoryInfo = new DirectoryInfo(xmlDirectory.OracleSqlDirectory.Trim());
                }
                else if (DatabaseProvider.Equals("MSSQL"))
                {
                    directoryInfo = new DirectoryInfo(xmlDirectory.MssqlSqlDirectory.Trim());
                }
                else
                {
                    directoryInfo = new DirectoryInfo(xmlDirectory.OracleSqlDirectory.Trim());
                }

                if (directoryInfo.Exists)
                {
                    result = new Dictionary<string, XmlOptionData>();

                    foreach (FileInfo file in directoryInfo.GetFiles())
                    {

                        XmlNode fileNode = ConvertFileInfoToXmlNode(file);
                        result.Add(fileNode.Name, new XmlOptionData(fileNode));
                    }
                }
                else
                {
                    xdoc.Load(xmlDirectory.OracleSqlDirectory);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void XmlSync(string DatabaseProvider, string SystemTypeCode)
        {
            this.xdoc = new XmlDocument();
            this.xmlDirectory = new XmlDirectory();
            
            try
            {
                //실행 시 에러가 발생하는 것을 파악하기 위해 개별 파일로 분리함
                DirectoryInfo? directoryInfo = null;
                if (DatabaseProvider.Equals("ORACLE"))
                {
                    if (SystemTypeCode.Equals("E"))
                    {
                        directoryInfo = new DirectoryInfo(@$"{xmlDirectory.OracleSqlDirectory.Trim()}\ELEC");
                    }

                    if (SystemTypeCode.Equals("A"))
                    {
                        directoryInfo = new DirectoryInfo(@$"{xmlDirectory.OracleSqlDirectory.Trim()}\ASSY");
                    }

                    if (SystemTypeCode.Equals("F"))
                    {
                        directoryInfo = new DirectoryInfo(@$"{xmlDirectory.OracleSqlDirectory.Trim()}\FORM");
                    }
                    xmlPath = @$"OracleXmls\{directoryInfo.Name}";
                    //  directoryInfo = new DirectoryInfo($"{xmlDirectory.OracleSqlDirectory.Trim()}\\FORM");
                }
                else if (DatabaseProvider.Equals("MSSQL"))
                {
                    directoryInfo = new DirectoryInfo(xmlDirectory.MssqlSqlDirectory.Trim());
                    xmlPath = @$"MssqlXmls\{directoryInfo.Name}";
                }
                else
                {
                    directoryInfo = new DirectoryInfo(xmlDirectory.OracleSqlDirectory.Trim());
                }

                if (directoryInfo.Exists)
                {
                    result = new Dictionary<string, XmlOptionData>();
                    
                    foreach (FileInfo file in directoryInfo.GetFiles())
                    {

                        XmlNode fileNode = ConvertFileInfoToXmlNode(file);
                        result.Add(fileNode.Name, new XmlOptionData(fileNode));
                    }
                }
                else
                {
                    xdoc.Load(xmlDirectory.OracleSqlDirectory);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }


        static XmlNode ConvertFileInfoToXmlNode(FileInfo fileInfo)
        {
            // XmlDocument 객체 생성
            using (StreamReader reader = fileInfo.OpenText())
            {
                // XML 데이터를 문자열로 읽음
                string xmlContent = reader.ReadToEnd();

                // XmlDocument 객체 생성 및 로드
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlContent);  // XML 문자열을 로드

                // XmlNode로 변환 (전체 문서 루트 노드 가져오기)
                XmlNode rootNode = xmlDoc.DocumentElement;
                
                return rootNode;
            }            
        }

        public Dictionary<string, XmlOptionData> OptionSqlListparser()
        {
            //Dictionary<string, XmlOptionData> result = new Dictionary<string, XmlOptionData>();

            // 특정 노드들을 필터링
         //   XmlNodeList nodes = xdoc.ChildNodes;

       //     XmlNode node = nodes[1];

        //    foreach (XmlNode cnode in node.ChildNodes)
        //    {
          //      result.Add(cnode.Name, new XmlOptionData(cnode));
        //    }
            
            return result;
        }

        public Dictionary<string, XmlOptionData> OptionSqlListparser(string sqlPath)
        {
            //Dictionary<string, XmlOptionData> result = new Dictionary<string, XmlOptionData>();
            // 특정 노드들을 필터링
            XmlNodeList nodes = xdoc.SelectNodes(sqlPath);

            foreach (XmlNode node in nodes)
            {
                foreach (XmlNode cnode in node.ChildNodes)
                {
                    //if(cnode.Name.Contains(CommonXml.Option)) {   

                    //   // result.Add(cnode.Name, new XmlOptionData(cnode));
                    //}
                }
            }
            return result;
        }

        public string MainSqlpaser(string sqlPath)
        {
            XmlNodeList nodes = xdoc.SelectNodes(sqlPath);

            return nodes[0].InnerText;
        }

        public string MainSqlpaser2(string sqlPath)
        {
            return result[sqlPath].Sql;
        }

    }
}
