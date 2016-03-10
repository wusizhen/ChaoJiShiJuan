using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    //试卷内容
    public class PaperContent
    {
        public Int32 paperID;
        public List<tbSingle> SRContent = new List<tbSingle>();
        public List<tbCheck> CBContent = new List<tbCheck>();
        public List<tbJudge> JDContent = new List<tbJudge>();
        public List<tbBlank> BFContent = new List<tbBlank>();
        public List<tbAnswer> SAContent = new List<tbAnswer>();

    }
}
