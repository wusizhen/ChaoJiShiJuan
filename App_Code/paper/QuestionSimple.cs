using System;

namespace Model
{
    public class QuestionSimple
    {
        private Int32 id;
       
        private Int32 subjectChapterID;
        
        private decimal difficulty;

        public decimal Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }
        public Int32 ID
        {
            get { return id; }
            set { id = value; }
        }
        public Int32 SubjectChapterID
        {
            get { return subjectChapterID; }
            set { subjectChapterID = value; }
        }
    }
}
