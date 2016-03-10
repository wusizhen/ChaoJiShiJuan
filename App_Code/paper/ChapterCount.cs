using System;
using System.Collections.Generic;

namespace Model
{
    public class ChapterCount
    {
        //章节范围SubjectChapterID
        private List<Int32> chapter = new List<Int32>();

        //章节数量
        private List<Int32> count = new List<Int32>();

       //暂时存放的题目
        private List<QuestionSimple> tempQuestion = new List<QuestionSimple>();

        //暂时存放的ID
        private List<Int32> tempID = new List<int>();

        public List<Int32> TempID
        {
            get { return tempID; }
            set { tempID = value; }
        }

        public List<QuestionSimple> TempQuestion
        {
            get { return tempQuestion; }
            set { tempQuestion = value; }
        }

        public List<Int32> Chapter
        {
            get { return chapter; }
            set { chapter = value; }
        }

        public List<Int32> Count
        {
            get { return count; }
            set { count = value; }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="chapter">传入的章节范围字符串</param>
        /// <param name="count">传入对应章节的出题数量字符串</param>
        public ChapterCount(String chapterStr, String countStr)
        {
            if (chapterStr != null && chapterStr != "" && countStr != null && countStr!="")
            {
                String[] tempChapter = chapterStr.Split('|');
                String[] tempCount = countStr.Split('|');
                if (tempChapter.Length == tempCount.Length)
                {
                    for (int i = 0; i < tempChapter.Length; i++)
                    {
                        try
                        {
                            chapter.Add(Convert.ToInt32(tempChapter[i]));
                            count.Add(Convert.ToInt32(tempCount[i]));
                        }
                        catch (Exception)
                        {

                            throw new Exception("章节字符串转化为数值时出错！");
                        }
                    }
                }                
            }
        }
    }
}
