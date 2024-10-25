using CustomUtils;
using System;
using System.Collections.Generic;
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
        private string mainSql;
        private Dictionary<string, XmlOptionData> optionSql;
        Dictionary<string, XmlOptionData> result;

        public XmlData()
        {
            XmlSync();
        }
        public XmlData(string sqlPath)
        {
            XmlSync();
           // this.mainSql = MainSqlpaser($@"{xmlDirectory.SqlDirectory}/MainSQL");
            this.mainSql = MainSqlpaser2(xmlDirectory.SqlDirectory);
            this.optionSql = OptionSqlListparser(xmlDirectory.SqlDirectory);
        }

        public string MainSql { get => mainSql; set => mainSql = value; }
        public Dictionary<string, XmlOptionData> OptionSql { get => optionSql; set => optionSql = value; }

        public void XmlSync() 
        {
            this.xdoc = new XmlDocument();
            this.xmlDirectory = new XmlDirectory();

            DirectoryInfo directoryInfo = new DirectoryInfo(xmlDirectory.SqlDirectory.Trim());
            try
            {
                //실행 시 에러가 발생하는 것을 파악하기 위해 개별 파일로 분리함
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
                    xdoc.Load(xmlDirectory.SqlDirectory);
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
