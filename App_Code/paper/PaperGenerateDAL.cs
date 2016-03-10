using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Model;
using System.Collections.Generic;
using DAL;
using System.Text;
using System.Data.SqlClient;

/// <summary>
///PaperGenerateDAL 的摘要说明
/// </summary>
public class PaperGenerateDAL
{
    tbPaper paper;
    Random random = new Random();
    SqlTransaction SqlTransaction;
    PaperContent paperContent = new PaperContent();

    public PaperGenerateDAL(tbPaper paper, SqlTransaction SqlTransaction)
    {
        this.paper = paper;
        this.SqlTransaction = SqlTransaction;
        this.paperContent.paperID = paper.id;
    }

    public PaperContent GetPaperContent()
    {
        if (paper.papertype == 1)
        {
            //随机试卷
            if (this.Generate() != -1m)
            {
                return paperContent;
            }
            return null;
        }
        else
        {
            //固定试卷
            try
            {
                SetPaperContent(GetListByString(paper.sr_list), GetListByString(paper.cb_list), GetListByString(paper.jd_list), GetListByString(paper.bf_list), GetListByString(paper.sa_list));
            }
            catch (Exception)
            {
                return null;
            }
            return paperContent;
        }
    }

    private List<int> GetListByString(string p)
    {
        List<int> list = new List<int>();
        String[] array = p.Split(',');
        for (int i = 0; i < array.Length; i++)
        {
            list.Add(Convert.ToInt32(array[i]));
        }
        return list;
    }

    private void SetPaperContent(List<Int32> list1, List<Int32> list2, List<Int32> list3, List<Int32> list4, List<Int32> list5)
    {
        tbSingleDAL singleDAL = new tbSingleDAL();
        tbCheckDAL checkDAL = new tbCheckDAL();
        tbJudgeDAL judgeDAL = new tbJudgeDAL();
        tbBlankDAL blankDAL = new tbBlankDAL();
        tbAnswerDAL answerDAl = new tbAnswerDAL();

        //单选题
        for (int i = 0; i < list1.Count; i++)
        {
            tbSingle single = singleDAL.GetModelTran(list1[i], SqlTransaction);
            //single.selectcount = single.selectcount + 1;
            //singleDAL.UpdateTran(single, SqlTransaction);
            paperContent.SRContent.Add(single);
        }

        //多选题
        for (int i = 0; i < list2.Count; i++)
        {
            tbCheck check = checkDAL.GetModelTran(list2[i], SqlTransaction);
            //check.selectcount = check.selectcount + 1;
            //checkDAL.UpdateTran(check, SqlTransaction);
            paperContent.CBContent.Add(check);
        }

        //判断题
        for (int i = 0; i < list3.Count; i++)
        {
            tbJudge judge = judgeDAL.GetModelTran(list3[i], SqlTransaction);
            //judge.selectcount = judge.selectcount + 1;
            //judgeDAL.UpdateTran(judge, SqlTransaction);
            paperContent.JDContent.Add(judge);
        }

        //填空题
        for (int i = 0; i < list4.Count; i++)
        {
            tbBlank blank = blankDAL.GetModelTran(list4[i], SqlTransaction);
            //blank.selectcount = blank.selectcount + 1;
            //blankDAL.UpdateTran(blank, SqlTransaction);
            paperContent.BFContent.Add(blank);
        }

        //简答题
        for (int i = 0; i < list5.Count; i++)
        {
            tbAnswer answer = answerDAl.GetModelTran(list5[i], SqlTransaction);
            //answer.selectcount = answer.selectcount + 1;
            //answerDAl.UpdateTran(answer, SqlTransaction);
            paperContent.SAContent.Add(answer);
        }
    }
    
    /// <summary>
    /// 生成试卷的具体题目
    /// </summary>        
    /// <returns>返回生成试卷的难度系数，-1表示生成失败</returns>
    private decimal Generate()
    {
        #region 定义辅助变量

        ChapterCount SR = new ChapterCount(paper.sr_chapterrange, paper.sr_countofeachchatper);
        ChapterCount CB = new ChapterCount(paper.cb_chapterrange, paper.cb_countofeachchapter);
        ChapterCount JD = new ChapterCount(paper.jd_chapterrange, paper.jd_countofeachchapter);
        ChapterCount BF = new ChapterCount(paper.bf_chapterrange, paper.bf_countofeachchapter);
        ChapterCount SA = new ChapterCount(paper.sa_chapterrange, paper.sa_countofeachchapter);

        //定义可用的题目数量
        int count = 0;
        //定义可用的难度系数集合
        List<decimal> diffArray = null;
        //定义实际难度系数
        decimal realDifficulty;
        //定义要求的难度系数
        decimal demandDifficulty;
        //定义难度系数总和
        decimal allDifficulty = 0;
        //定义已经出了的总题目数
        Int32 allCount = 0;
        //定义暂时题目库
        Dictionary<Int32, QuestionSimple> dictionary = null;
        //定义满足某个难度系数的题目库
        List<Int32> smallDictionary = null;
        //定义随机产生的难度系数
        decimal randomDifficulty = 0;
        //定义各个类型题目的难度系数数组
        decimal[] diffSumArray = new decimal[] { 0, 0, 0, 0, 0 };
        //定义从smallDictionary取出题目所要用到的随机数
        Int32 randomSmall = -1;
        //定义取出的主键ID值
        Int32 id = 0;
        #endregion

        #region 单选题抽取

        //获得实际要求的难度系数
        demandDifficulty = (decimal)paper.sr_diff;
        //实际难度系数，-1表示没有题目
        realDifficulty = -1;
        //重新初始化数据
        allCount = 0;
        allDifficulty = 0;
        //判断是否设置章节详细数目
        if (SR.Chapter.Count != 0 && SR.Count.Count != 0)
        {
            //已设置章节详细数目

            //============================循环各章节
            for (int i = 0; i < SR.Chapter.Count && allCount < paper.sr_count; i++)
            {
                //获取第i个章节的可用题目数
                count = GetCountOfChapter("tbSingle", SR.Chapter[i]);

                //判断第i个章节的可用题目数是否足够
                if (count >= SR.Count[i])
                {
                    //清空dictionary，防止内存溢出
                    if (dictionary != null)
                    {
                        dictionary.Clear();
                    }
                    //清空smallDictionary，防止内存溢出
                    if (smallDictionary != null)
                    {
                        smallDictionary.Clear();
                    }
                    //获得第i个章节的题目库
                    dictionary = GetQuesOfChapter("tbSingle", SR.Chapter[i]);
                    //获取第i个章节的可用难度系数
                    diffArray = GetDiffOfChapter("tbSingle", SR.Chapter[i]);

                    //=====================循环第i个章节的各个题目
                    for (int j = 0; j < SR.Count[i]; j++)
                    {
                        randomDifficulty = GetRandomDiff(diffArray, realDifficulty, demandDifficulty, allCount);

                        //从dictionary筛选出难度系数为randomDifficulty的子题目库
                        smallDictionary = GetSmallQuestion(dictionary, randomDifficulty);
                        //产生另一个随机数
                        if (smallDictionary.Count != 0)
                        {
                            randomSmall = random.Next(0, smallDictionary.Count);
                            //取出smallDictionary中的一个Key
                            id = (Int32)smallDictionary[randomSmall];
                        }
                        //取出题目
                        SR.TempQuestion.Add(dictionary[id]);
                        SR.TempID.Add(id);
                        //删除dictionary中的题目，防止重复
                        dictionary.Remove(id);
                        //判断该难度系数是否还存在
                        if (smallDictionary.Count == 1)
                        {
                            //从diffArray中删除该难度系数
                            diffArray.Remove(randomDifficulty);
                        }
                        //总题目数加1
                        allCount++;
                        //算出难度系数总和
                        allDifficulty += randomDifficulty;
                        //算出现在的难度系数
                        realDifficulty = (decimal)allDifficulty / allCount;

                        //清空smallDictionary，防止内存溢出
                        if (smallDictionary != null)
                        {
                            smallDictionary.Clear();
                        }
                    }
                }
                else
                {
                    //题目不足
                    return -1;
                }
            }
        }
        else
        {
            //没有设置章节详细数目

            //获取该科目的可用题目数
            count = GetCountOfSubject("tbSingle", paper.subjectid);

            //判断该科目的可用题目数是否足够
            if (count >= paper.sr_count)
            {
                //足够                   

                //清空dictionary，防止内存溢出
                if (dictionary != null)
                {
                    dictionary.Clear();
                }
                //清空smallDictionary，防止内存溢出
                if (smallDictionary != null)
                {
                    smallDictionary.Clear();
                }
                //获得该科目的题目库
                dictionary = GetQuesOfSubject("tbSingle", paper.subjectid);
                //获取该科目的可用难度系数
                diffArray = GetDiffOfSubject("tbSingle", paper.subjectid);
                //================循环抽出各个题目
                for (int i = 0; i < paper.sr_count; i++)
                {
                    //产生随机难度系数
                    randomDifficulty = GetRandomDiff(diffArray, realDifficulty, demandDifficulty, allCount);
                    //从dictionary筛选出难度系数为randomDifficulty的子题目库
                    smallDictionary = GetSmallQuestion(dictionary, randomDifficulty);
                    //产生另一个随机数
                    if (smallDictionary.Count != 0)
                    {
                        randomSmall = random.Next(0, smallDictionary.Count);
                        //取出smallDictionary中的一个Key
                        id = (Int32)smallDictionary[randomSmall];
                    }
                    //取出题目
                    SR.TempQuestion.Add(dictionary[id]);
                    SR.TempID.Add(id);
                    //删除dictionary中的题目，防止重复
                    dictionary.Remove(id);
                    //判断该难度系数是否还存在
                    if (smallDictionary.Count == 1)
                    {
                        //从diffArray中删除该难度系数
                        diffArray.Remove(randomDifficulty);
                    }
                    //总题目数加1
                    allCount++;
                    //算出难度系数总和
                    allDifficulty += randomDifficulty;
                    //算出现在的难度系数
                    realDifficulty = (decimal)allDifficulty / allCount;

                    //清空smallDictionary，防止内存溢出
                    if (smallDictionary != null)
                    {
                        smallDictionary.Clear();
                    }
                }
            }
            else
            {
                //题目不足
                return -1;
            }
        }

        //保存难度系数
        diffSumArray[0] = allDifficulty;
        #endregion

        #region 多选题抽取

        //获得实际要求的难度系数
        demandDifficulty = (decimal)paper.cb_diff;
        //实际难度系数，-1表示没有题目
        realDifficulty = -1;
        //重新初始化数据
        allCount = 0;
        allDifficulty = 0;
        //判断是否设置章节详细数目
        if (CB.Chapter.Count != 0 && CB.Count.Count != 0)
        {
            //已设置章节详细数目

            //============================循环各章节
            for (int i = 0; i < CB.Chapter.Count && allCount < paper.cb_count; i++)
            {
                //获取第i个章节的可用题目数
                count = GetCountOfChapter("tbCheck", CB.Chapter[i]);

                //判断第i个章节的可用题目数是否足够
                if (count >= CB.Count[i])
                {
                    //清空dictionary，防止内存溢出
                    if (dictionary != null)
                    {
                        dictionary.Clear();
                    }
                    //清空smallDictionary，防止内存溢出
                    if (smallDictionary != null)
                    {
                        smallDictionary.Clear();
                    }
                    //获得第i个章节的题目库
                    dictionary = GetQuesOfChapter("tbCheck", CB.Chapter[i]);
                    //获取第i个章节的可用难度系数
                    diffArray = GetDiffOfChapter("tbCheck", CB.Chapter[i]);

                    //=====================循环第i个章节的各个题目
                    for (int j = 0; j < CB.Count[i]; j++)
                    {
                        randomDifficulty = GetRandomDiff(diffArray, realDifficulty, demandDifficulty, allCount);

                        //从dictionary筛选出难度系数为randomDifficulty的子题目库
                        smallDictionary = GetSmallQuestion(dictionary, randomDifficulty);
                        //产生另一个随机数
                        if (smallDictionary.Count != 0)
                        {
                            randomSmall = random.Next(0, smallDictionary.Count);
                            //取出smallDictionary中的一个Key
                            id = (Int32)smallDictionary[randomSmall];
                        }
                        //取出题目
                        CB.TempQuestion.Add(dictionary[id]);
                        CB.TempID.Add(id);
                        //删除dictionary中的题目，防止重复
                        dictionary.Remove(id);
                        //判断该难度系数是否还存在
                        if (smallDictionary.Count == 1)
                        {
                            //从diffArray中删除该难度系数
                            diffArray.Remove(randomDifficulty);
                        }
                        //总题目数加1
                        allCount++;
                        //算出难度系数总和
                        allDifficulty += randomDifficulty;
                        //算出现在的难度系数
                        realDifficulty = (decimal)allDifficulty / allCount;

                        //清空smallDictionary，防止内存溢出
                        if (smallDictionary != null)
                        {
                            smallDictionary.Clear();
                        }
                    }
                }
                else
                {
                    //题目不足
                    return -1;
                }
            }
        }
        else
        {
            //没有设置章节详细数目

            //获取该科目的可用题目数
            count = GetCountOfSubject("tbCheck", paper.subjectid);

            //判断该科目的可用题目数是否足够
            if (count >= paper.cb_count)
            {
                //足够                   

                //清空dictionary，防止内存溢出
                if (dictionary != null)
                {
                    dictionary.Clear();
                }
                //清空smallDictionary，防止内存溢出
                if (smallDictionary != null)
                {
                    smallDictionary.Clear();
                }
                //获得该科目的题目库
                dictionary = GetQuesOfSubject("tbCheck", paper.subjectid);
                //获取该科目的可用难度系数
                diffArray = GetDiffOfSubject("tbCheck", paper.subjectid);
                //================循环抽出各个题目
                for (int i = 0; i < paper.cb_count; i++)
                {
                    //产生随机难度系数
                    randomDifficulty = GetRandomDiff(diffArray, realDifficulty, demandDifficulty, allCount);
                    //从dictionary筛选出难度系数为randomDifficulty的子题目库
                    smallDictionary = GetSmallQuestion(dictionary, randomDifficulty);
                    //产生另一个随机数
                    if (smallDictionary.Count != 0)
                    {
                        randomSmall = random.Next(0, smallDictionary.Count);
                        //取出smallDictionary中的一个Key
                        id = (Int32)smallDictionary[randomSmall];
                    }
                    //取出题目
                    CB.TempQuestion.Add(dictionary[id]);
                    CB.TempID.Add(id);
                    //删除dictionary中的题目，防止重复
                    dictionary.Remove(id);
                    //判断该难度系数是否还存在
                    if (smallDictionary.Count == 1)
                    {
                        //从diffArray中删除该难度系数
                        diffArray.Remove(randomDifficulty);
                    }
                    //总题目数加1
                    allCount++;
                    //算出难度系数总和
                    allDifficulty += randomDifficulty;
                    //算出现在的难度系数
                    realDifficulty = (decimal)allDifficulty / allCount;

                    //清空smallDictionary，防止内存溢出
                    if (smallDictionary != null)
                    {
                        smallDictionary.Clear();
                    }
                }
            }
            else
            {
                //题目不足
                return -1;
            }
        }

        //保存难度系数
        diffSumArray[1] = allDifficulty;
        #endregion

        #region 判断题抽取

        //获得实际要求的难度系数
        demandDifficulty = (decimal)paper.jd_diff;
        //实际难度系数，-1表示没有题目
        realDifficulty = -1;
        //重新初始化数据
        allCount = 0;
        allDifficulty = 0;
        //判断是否设置章节详细数目
        if (JD.Chapter.Count != 0 && JD.Count.Count != 0)
        {
            //已设置章节详细数目

            //============================循环各章节
            for (int i = 0; i < JD.Chapter.Count && allCount < paper.jd_count; i++)
            {
                //获取第i个章节的可用题目数
                count = GetCountOfChapter("tbJudge", JD.Chapter[i]);

                //判断第i个章节的可用题目数是否足够
                if (count >= JD.Count[i])
                {
                    //清空dictionary，防止内存溢出
                    if (dictionary != null)
                    {
                        dictionary.Clear();
                    }
                    //清空smallDictionary，防止内存溢出
                    if (smallDictionary != null)
                    {
                        smallDictionary.Clear();
                    }
                    //获得第i个章节的题目库
                    dictionary = GetQuesOfChapter("tbJudge", JD.Chapter[i]);
                    //获取第i个章节的可用难度系数
                    diffArray = GetDiffOfChapter("tbJudge", JD.Chapter[i]);

                    //=====================循环第i个章节的各个题目
                    for (int j = 0; j < JD.Count[i]; j++)
                    {
                        randomDifficulty = GetRandomDiff(diffArray, realDifficulty, demandDifficulty, allCount);

                        //从dictionary筛选出难度系数为randomDifficulty的子题目库
                        smallDictionary = GetSmallQuestion(dictionary, randomDifficulty);
                        //产生另一个随机数
                        if (smallDictionary.Count != 0)
                        {
                            randomSmall = random.Next(0, smallDictionary.Count);
                            //取出smallDictionary中的一个Key
                            id = (Int32)smallDictionary[randomSmall];
                        }
                        //取出题目
                        JD.TempQuestion.Add(dictionary[id]);
                        JD.TempID.Add(id);
                        //删除dictionary中的题目，防止重复
                        dictionary.Remove(id);
                        //判断该难度系数是否还存在
                        if (smallDictionary.Count == 1)
                        {
                            //从diffArray中删除该难度系数
                            diffArray.Remove(randomDifficulty);
                        }
                        //总题目数加1
                        allCount++;
                        //算出难度系数总和
                        allDifficulty += randomDifficulty;
                        //算出现在的难度系数
                        realDifficulty = (decimal)allDifficulty / allCount;

                        //清空smallDictionary，防止内存溢出
                        if (smallDictionary != null)
                        {
                            smallDictionary.Clear();
                        }
                    }
                }
                else
                {
                    //题目不足
                    return -1;
                }
            }
        }
        else
        {
            //没有设置章节详细数目

            //获取该科目的可用题目数
            count = GetCountOfSubject("tbJudge", paper.subjectid);

            //判断该科目的可用题目数是否足够
            if (count >= paper.jd_count)
            {
                //足够                   

                //清空dictionary，防止内存溢出
                if (dictionary != null)
                {
                    dictionary.Clear();
                }
                //清空smallDictionary，防止内存溢出
                if (smallDictionary != null)
                {
                    smallDictionary.Clear();
                }
                //获得该科目的题目库
                dictionary = GetQuesOfSubject("tbJudge", paper.subjectid);
                //获取该科目的可用难度系数
                diffArray = GetDiffOfSubject("tbJudge", paper.subjectid);
                //================循环抽出各个题目
                for (int i = 0; i < paper.jd_count; i++)
                {
                    //产生随机难度系数
                    randomDifficulty = GetRandomDiff(diffArray, realDifficulty, demandDifficulty, allCount);
                    //从dictionary筛选出难度系数为randomDifficulty的子题目库
                    smallDictionary = GetSmallQuestion(dictionary, randomDifficulty);
                    //产生另一个随机数
                    if (smallDictionary.Count != 0)
                    {
                        randomSmall = random.Next(0, smallDictionary.Count);
                        //取出smallDictionary中的一个Key
                        id = (Int32)smallDictionary[randomSmall];
                    }
                    //取出题目
                    JD.TempQuestion.Add(dictionary[id]);
                    JD.TempID.Add(id);
                    //删除dictionary中的题目，防止重复
                    dictionary.Remove(id);
                    //判断该难度系数是否还存在
                    if (smallDictionary.Count == 1)
                    {
                        //从diffArray中删除该难度系数
                        diffArray.Remove(randomDifficulty);
                    }
                    //总题目数加1
                    allCount++;
                    //算出难度系数总和
                    allDifficulty += randomDifficulty;
                    //算出现在的难度系数
                    realDifficulty = (decimal)allDifficulty / allCount;

                    //清空smallDictionary，防止内存溢出
                    if (smallDictionary != null)
                    {
                        smallDictionary.Clear();
                    }
                }
            }
            else
            {
                //题目不足
                return -1;
            }
        }

        //保存难度系数
        diffSumArray[2] = allDifficulty;
        #endregion

        #region 填空题抽取

        //获得实际要求的难度系数
        demandDifficulty = (decimal)paper.bf_diff;
        //实际难度系数，-1表示没有题目
        realDifficulty = -1;
        //重新初始化数据
        allCount = 0;
        allDifficulty = 0;
        //判断是否设置章节详细数目
        if (BF.Chapter.Count != 0 && BF.Count.Count != 0)
        {
            //已设置章节详细数目

            //============================循环各章节
            for (int i = 0; i < BF.Chapter.Count && allCount < paper.bf_count; i++)
            {
                //获取第i个章节的可用题目数
                count = GetCountOfChapter("tbBlank", BF.Chapter[i]);

                //判断第i个章节的可用题目数是否足够
                if (count >= BF.Count[i])
                {
                    //清空dictionary，防止内存溢出
                    if (dictionary != null)
                    {
                        dictionary.Clear();
                    }
                    //清空smallDictionary，防止内存溢出
                    if (smallDictionary != null)
                    {
                        smallDictionary.Clear();
                    }
                    //获得第i个章节的题目库
                    dictionary = GetQuesOfChapter("tbBlank", BF.Chapter[i]);
                    //获取第i个章节的可用难度系数
                    diffArray = GetDiffOfChapter("tbBlank", BF.Chapter[i]);

                    //=====================循环第i个章节的各个题目
                    for (int j = 0; j < BF.Count[i]; j++)
                    {
                        randomDifficulty = GetRandomDiff(diffArray, realDifficulty, demandDifficulty, allCount);

                        //从dictionary筛选出难度系数为randomDifficulty的子题目库
                        smallDictionary = GetSmallQuestion(dictionary, randomDifficulty);
                        //产生另一个随机数
                        if (smallDictionary.Count != 0)
                        {
                            randomSmall = random.Next(0, smallDictionary.Count);
                            //取出smallDictionary中的一个Key
                            id = (Int32)smallDictionary[randomSmall];
                        }
                        //取出题目
                        BF.TempQuestion.Add(dictionary[id]);
                        BF.TempID.Add(id);
                        //删除dictionary中的题目，防止重复
                        dictionary.Remove(id);
                        //判断该难度系数是否还存在
                        if (smallDictionary.Count == 1)
                        {
                            //从diffArray中删除该难度系数
                            diffArray.Remove(randomDifficulty);
                        }
                        //总题目数加1
                        allCount++;
                        //算出难度系数总和
                        allDifficulty += randomDifficulty;
                        //算出现在的难度系数
                        realDifficulty = (decimal)allDifficulty / allCount;

                        //清空smallDictionary，防止内存溢出
                        if (smallDictionary != null)
                        {
                            smallDictionary.Clear();
                        }
                    }
                }
                else
                {
                    //题目不足
                    return -1;
                }
            }
        }
        else
        {
            //没有设置章节详细数目

            //获取该科目的可用题目数
            count = GetCountOfSubject("tbBlank", paper.subjectid);

            //判断该科目的可用题目数是否足够
            if (count >= paper.bf_count)
            {
                //足够                   

                //清空dictionary，防止内存溢出
                if (dictionary != null)
                {
                    dictionary.Clear();
                }
                //清空smallDictionary，防止内存溢出
                if (smallDictionary != null)
                {
                    smallDictionary.Clear();
                }
                //获得该科目的题目库
                dictionary = GetQuesOfSubject("tbBlank", paper.subjectid);
                //获取该科目的可用难度系数
                diffArray = GetDiffOfSubject("tbBlank", paper.subjectid);
                //================循环抽出各个题目
                for (int i = 0; i < paper.bf_count; i++)
                {
                    //产生随机难度系数
                    randomDifficulty = GetRandomDiff(diffArray, realDifficulty, demandDifficulty, allCount);
                    //从dictionary筛选出难度系数为randomDifficulty的子题目库
                    smallDictionary = GetSmallQuestion(dictionary, randomDifficulty);
                    //产生另一个随机数
                    if (smallDictionary.Count != 0)
                    {
                        randomSmall = random.Next(0, smallDictionary.Count);
                        //取出smallDictionary中的一个Key
                        id = (Int32)smallDictionary[randomSmall];
                    }
                    //取出题目
                    BF.TempQuestion.Add(dictionary[id]);
                    BF.TempID.Add(id);
                    //删除dictionary中的题目，防止重复
                    dictionary.Remove(id);
                    //判断该难度系数是否还存在
                    if (smallDictionary.Count == 1)
                    {
                        //从diffArray中删除该难度系数
                        diffArray.Remove(randomDifficulty);
                    }
                    //总题目数加1
                    allCount++;
                    //算出难度系数总和
                    allDifficulty += randomDifficulty;
                    //算出现在的难度系数
                    realDifficulty = (decimal)allDifficulty / allCount;

                    //清空smallDictionary，防止内存溢出
                    if (smallDictionary != null)
                    {
                        smallDictionary.Clear();
                    }
                }
            }
            else
            {
                //题目不足
                return -1;
            }
        }

        //保存难度系数
        diffSumArray[3] = allDifficulty;
        #endregion

        #region 简答题抽取

        //获得实际要求的难度系数
        demandDifficulty = (decimal)paper.sa_diff;
        //实际难度系数，-1表示没有题目
        realDifficulty = -1;
        //重新初始化数据
        allCount = 0;
        allDifficulty = 0;
        //判断是否设置章节详细数目
        if (SA.Chapter.Count != 0 && SA.Count.Count != 0)
        {
            //已设置章节详细数目

            //============================循环各章节
            for (int i = 0; i < SA.Chapter.Count && allCount < paper.sa_count; i++)
            {
                //获取第i个章节的可用题目数
                count = GetCountOfChapter("tbAnswer", SA.Chapter[i]);

                //判断第i个章节的可用题目数是否足够
                if (count >= SA.Count[i])
                {
                    //清空dictionary，防止内存溢出
                    if (dictionary != null)
                    {
                        dictionary.Clear();
                    }
                    //清空smallDictionary，防止内存溢出
                    if (smallDictionary != null)
                    {
                        smallDictionary.Clear();
                    }
                    //获得第i个章节的题目库
                    dictionary = GetQuesOfChapter("tbAnswer", SA.Chapter[i]);
                    //获取第i个章节的可用难度系数
                    diffArray = GetDiffOfChapter("tbAnswer", SA.Chapter[i]);

                    //=====================循环第i个章节的各个题目
                    for (int j = 0; j < SA.Count[i]; j++)
                    {
                        randomDifficulty = GetRandomDiff(diffArray, realDifficulty, demandDifficulty, allCount);

                        //从dictionary筛选出难度系数为randomDifficulty的子题目库
                        smallDictionary = GetSmallQuestion(dictionary, randomDifficulty);
                        //产生另一个随机数
                        if (smallDictionary.Count != 0)
                        {
                            randomSmall = random.Next(0, smallDictionary.Count);
                            //取出smallDictionary中的一个Key
                            id = (Int32)smallDictionary[randomSmall];
                        }
                        //取出题目
                        SA.TempQuestion.Add(dictionary[id]);
                        SA.TempID.Add(id);
                        //删除dictionary中的题目，防止重复
                        dictionary.Remove(id);
                        //判断该难度系数是否还存在
                        if (smallDictionary.Count == 1)
                        {
                            //从diffArray中删除该难度系数
                            diffArray.Remove(randomDifficulty);
                        }
                        //总题目数加1
                        allCount++;
                        //算出难度系数总和
                        allDifficulty += randomDifficulty;
                        //算出现在的难度系数
                        realDifficulty = (decimal)allDifficulty / allCount;

                        //清空smallDictionary，防止内存溢出
                        if (smallDictionary != null)
                        {
                            smallDictionary.Clear();
                        }
                    }
                }
                else
                {
                    //题目不足
                    return -1;
                }
            }
        }
        else
        {
            //没有设置章节详细数目

            //获取该科目的可用题目数
            count = GetCountOfSubject("tbAnswer", paper.subjectid);

            //判断该科目的可用题目数是否足够
            if (count >= paper.sa_count)
            {
                //足够                   

                //清空dictionary，防止内存溢出
                if (dictionary != null)
                {
                    dictionary.Clear();
                }
                //清空smallDictionary，防止内存溢出
                if (smallDictionary != null)
                {
                    smallDictionary.Clear();
                }
                //获得该科目的题目库
                dictionary = GetQuesOfSubject("tbAnswer", paper.subjectid);
                //获取该科目的可用难度系数
                diffArray = GetDiffOfSubject("tbAnswer", paper.subjectid);
                //================循环抽出各个题目
                for (int i = 0; i < paper.sa_count; i++)
                {
                    //产生随机难度系数
                    randomDifficulty = GetRandomDiff(diffArray, realDifficulty, demandDifficulty, allCount);
                    //从dictionary筛选出难度系数为randomDifficulty的子题目库
                    smallDictionary = GetSmallQuestion(dictionary, randomDifficulty);
                    //产生另一个随机数
                    if (smallDictionary.Count != 0)
                    {
                        randomSmall = random.Next(0, smallDictionary.Count);
                        //取出smallDictionary中的一个Key
                        id = (Int32)smallDictionary[randomSmall];
                    }
                    //取出题目
                    SA.TempQuestion.Add(dictionary[id]);
                    SA.TempID.Add(id);
                    //删除dictionary中的题目，防止重复
                    dictionary.Remove(id);
                    //判断该难度系数是否还存在
                    if (smallDictionary.Count == 1)
                    {
                        //从diffArray中删除该难度系数
                        diffArray.Remove(randomDifficulty);
                    }
                    //总题目数加1
                    allCount++;
                    //算出难度系数总和
                    allDifficulty += randomDifficulty;
                    //算出现在的难度系数
                    realDifficulty = (decimal)allDifficulty / allCount;

                    //清空smallDictionary，防止内存溢出
                    if (smallDictionary != null)
                    {
                        smallDictionary.Clear();
                    }
                }
            }
            else
            {
                //题目不足
                return -1;
            }
        }

        //保存难度系数
        diffSumArray[4] = allDifficulty;
        #endregion

        SetPaperContent(SR.TempID, CB.TempID, JD.TempID, BF.TempID, SA.TempID);

        //计算出总的难度系数
        realDifficulty = ComputeDiff(diffSumArray);
        return realDifficulty;
    }

    #region 私有方法
    /// <summary>
    /// 获取某种类型某一章题目的可用难度系数
    /// </summary>
    /// <param name="table">题型的表名</param>
    /// <param name="subjectChapterID">某个章节ID</param>
    /// <returns></returns>
    private List<decimal> GetDiffOfChapter(String tableName, Int32 subjectChapterID)
    {
        List<decimal> difficulty = new List<decimal>();
        StringBuilder sqlStr = new StringBuilder();

        sqlStr.Append("SELECT DISTINCT [diff] FROM ");
        sqlStr.Append(tableName);
        sqlStr.Append(" WHERE chapterid=@chapterid and questype=1");

        DataSet ds = SQLHelper.ExecuteDataset(SqlTransaction, CommandType.Text, sqlStr.ToString(), new SqlParameter("@chapterid", subjectChapterID));

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            difficulty.Add(Convert.ToDecimal(ds.Tables[0].Rows[i][0].ToString()));
        }

        return difficulty;

    }

    /// <summary>
    /// 获取某科目的可用难度系数
    /// </summary>
    /// <param name="table">题型的表名</param>
    /// <param name="subjectID">科目ID</param>
    /// <returns></returns>       
    private List<decimal> GetDiffOfSubject(String tableName, Int32 subjectID)
    {
        List<decimal> difficulty = new List<decimal>();
        StringBuilder sqlStr = new StringBuilder();

        sqlStr.Append("SELECT DISTINCT [diff] FROM ");
        sqlStr.Append(tableName);
        sqlStr.Append(" WHERE chapterid IN (SELECT DISTINCT [id] FROM [tbChapter] WHERE subjectid=@subjectid) and questype=1");

        DataSet ds = SQLHelper.ExecuteDataset(SqlTransaction, CommandType.Text, sqlStr.ToString(), new SqlParameter("@subjectid", subjectID));

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            difficulty.Add(Convert.ToDecimal(ds.Tables[0].Rows[i][0].ToString()));
        }

        return difficulty;

    }

    /// <summary>
    /// 获得某种类型某个章节的可用题目数
    /// </summary>
    /// <param name="tableName">题型的表名</param>
    /// <param name="subjectChapterID">某个章节ID</param>
    /// <returns></returns>
    private Int32 GetCountOfChapter(String tableName, Int32 subjectChapterID)
    {
        StringBuilder sqlStr = new StringBuilder();

        sqlStr.Append("SELECT COUNT(*) FROM ");
        sqlStr.Append(tableName);
        sqlStr.Append(" WHERE chapterid=@chapterid and questype=1");

        return (Int32)SQLHelper.ExecuteScalar(SqlTransaction, CommandType.Text, sqlStr.ToString(), new SqlParameter("@chapterid", subjectChapterID));
    }

    /// <summary>
    /// 获得某科目的可用题目数
    /// </summary>
    /// <param name="tableName">题型的表名</param>
    /// <param name="subjectChapterID">某个章节ID</param>
    /// <returns></returns>
    private Int32 GetCountOfSubject(String tableName, Int32 subjectID)
    {
        StringBuilder sqlStr = new StringBuilder();

        sqlStr.Append("SELECT COUNT(*) FROM ");
        sqlStr.Append(tableName);
        sqlStr.Append(" WHERE chapterid IN (SELECT DISTINCT [id] FROM [tbChapter] WHERE subjectid=@subjectid) and questype=1");

        return (Int32)SQLHelper.ExecuteScalar(SqlTransaction, CommandType.Text, sqlStr.ToString(), new SqlParameter("@subjectid", subjectID));
    }

    /// <summary>
    /// 获取存放某一章节题目的临时字典
    /// </summary>
    /// <param name="tableName">表的名字</param>
    /// <param name="subjectChapterID">章节ID</param>
    /// <returns></returns>
    private Dictionary<Int32, QuestionSimple> GetQuesOfChapter(String tableName, Int32 subjectChapterID)
    {
        Dictionary<Int32, QuestionSimple> dictonary = new Dictionary<int, QuestionSimple>();
        StringBuilder sqlStr = new StringBuilder();

        sqlStr.Append("SELECT id,chapterid,diff FROM ");
        sqlStr.Append(tableName);
        sqlStr.Append(" WHERE chapterid=@chapterid and questype=1");

        DataSet ds = SQLHelper.ExecuteDataset(SqlTransaction, CommandType.Text, sqlStr.ToString(), new SqlParameter("@chapterid", subjectChapterID));

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            QuestionSimple qs = new QuestionSimple();
            qs.ID = (Int32)ds.Tables[0].Rows[i][0];
            qs.SubjectChapterID = (Int32)ds.Tables[0].Rows[i][1];
            qs.Difficulty = Convert.ToDecimal(ds.Tables[0].Rows[i][2].ToString());
            dictonary.Add(qs.ID, qs);
        }

        return dictonary;
    }

    /// <summary>
    /// 获取存放某一科目题目的临时字典
    /// </summary>
    /// <param name="tableName">表的名字</param>
    /// <param name="subjectChapterID">科目ID</param>
    /// <returns></returns>
    private Dictionary<Int32, QuestionSimple> GetQuesOfSubject(String tableName, Int32 subjectID)
    {
        Dictionary<Int32, QuestionSimple> dictonary = new Dictionary<int, QuestionSimple>();
        StringBuilder sqlStr = new StringBuilder();

        sqlStr.Append("SELECT id,chapterid,diff FROM ");
        sqlStr.Append(tableName);
        sqlStr.Append(" WHERE chapterid IN (SELECT DISTINCT [id] FROM [tbChapter] WHERE subjectid=@subjectid) and questype=1");

        DataSet ds = SQLHelper.ExecuteDataset(SqlTransaction, CommandType.Text, sqlStr.ToString(), new SqlParameter("@subjectid", subjectID));

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            QuestionSimple qs = new QuestionSimple();
            qs.ID = (Int32)ds.Tables[0].Rows[i][0];
            qs.SubjectChapterID = (Int32)ds.Tables[0].Rows[i][1];
            qs.Difficulty = Convert.ToDecimal(ds.Tables[0].Rows[i][2].ToString());
            dictonary.Add(qs.ID, qs);
        }

        return dictonary;
    }

    /// <summary>
    /// 从一个大的dictionary中筛选出难度系数为condition的List(只包含它的key)
    /// </summary>
    /// <param name="bigDictionary"></param>
    /// <param name="condition"></param>
    /// <returns></returns>
    private List<Int32> GetSmallQuestion(Dictionary<Int32, QuestionSimple> bigDictionary, decimal condition)
    {
        List<Int32> small = new List<Int32>();

        QuestionSimple qs = null;

        foreach (Int32 item in bigDictionary.Keys)
        {
            qs = bigDictionary[item];
            if (qs.Difficulty == condition)
            {
                small.Add(qs.ID);
            }
        }
        return small;
    }

    /// <summary>
    /// 判断数字number是否存在于array中
    /// </summary>
    /// <param name="array"></param>
    /// <param name="number"></param>
    /// <returns></returns>
    private bool IsExistDiff(List<decimal> array, decimal number)
    {
        bool b = true;
        int i;

        for (i = 0; i < array.Count; i++)
        {
            if (number == array[i])
                break;
        }
        if (i == array.Count)
            b = false;
        return b;

    }

    /// <summary>
    /// 获得随机的，可用的难度系数,-1表示生成失败
    /// </summary>
    /// <param name="diffArray">可用的难度系数集合</param>
    /// <param name="realDifficulty">目前的难度系数</param>
    /// <param name="demandDifficulty">要求的难度系数</param>
    /// <param name="allCount">已出的题目数量</param>
    /// <returns></returns>
    private decimal GetRandomDiff(List<decimal> diffArray, decimal realDifficulty, decimal demandDifficulty, Int32 allCount)
    {
        //再产生一个随机数，使各试卷的差异性拉开,即1/3的机会
        Int32 randomMore = random.Next(0, 3);

        decimal randomDifficulty = -1;
        //第一次随机产生难度系数
        if (realDifficulty == -1 || randomMore == 0)
        {
            randomDifficulty = (decimal)(random.Next(1, 5));
            //没有该难度系数的时候继续循环
            while (!IsExistDiff(diffArray, randomDifficulty))
            {
                //如果没有可用的难度系数，则跳出循环
                if (diffArray.Count == 0)
                {
                    break;
                }
                //获得一个随机难度系数
                randomDifficulty = (decimal)(random.Next(1, 5));
            }
        }
        else
        {
            //非第一次则要根据实际的难度系数才计算出来，以保证实际难度系数与要求难度系数相近
            randomDifficulty = Convert.ToDecimal(((int)((Convert.ToDouble(demandDifficulty) * (allCount + 1) - Convert.ToDouble(realDifficulty) * allCount))));
            if (randomDifficulty < 1m)
            {
                randomDifficulty = 1m;
            }
            if (randomDifficulty > 5m)
            {
                randomDifficulty = 5m;
            }
            if (!IsExistDiff(diffArray, randomDifficulty))
            {
                //不存在该难度系数，就寻找最接近的                
                randomDifficulty = LookupDiff(diffArray, randomDifficulty);
            }

        }
        return randomDifficulty;
    }

    /// <summary>
    /// 从集合diffArray中获得最接近randomDifficulty的难度系数,-1表示一个都没找到
    /// </summary>
    /// <param name="diffArray">可用难度系数集合</param>
    /// <param name="randomDifficulty">最优的难度系数</param>
    /// <returns></returns>
    private decimal LookupDiff(List<decimal> diffArray, decimal randomDifficulty)
    {
        int i;
        //最多查找4次
        for (i = 0; i < 4; i++)
        {
            //向上查找
            if (IsExistDiff(diffArray, randomDifficulty + 1m * (i + 1)))
            {
                randomDifficulty = randomDifficulty + 1m * (i + 1);
                break;
            }
            //向下查找
            if (IsExistDiff(diffArray, randomDifficulty - 1m * (i + 1)))
            {
                randomDifficulty = randomDifficulty - 1m * (i + 1);
                break;
            }
        }
        if (i == 5)
        {
            randomDifficulty = -1;
        }
        return randomDifficulty;
    }

    /// <summary>
    /// 计算出总的难度系数
    /// </summary>
    /// <param name="diffSumArray"></param>
    /// <returns></returns>
    private decimal ComputeDiff(decimal[] diffSumArray)
    {
        decimal sum = diffSumArray[0] * paper.sr_scoreofeach +
                    diffSumArray[1] * paper.cb_scoreofeach +
                    diffSumArray[2] * paper.jd_scoreofeach +
                    diffSumArray[3] * paper.bf_scoreofeach +
                    diffSumArray[4] * paper.sa_scoreofeach;

        decimal weigth = paper.sr_count * paper.sr_scoreofeach +
                        paper.cb_count * paper.cb_scoreofeach +
                        paper.jd_count * paper.jd_scoreofeach +
                        paper.bf_count * paper.bf_scoreofeach +
                        paper.sa_count * paper.sa_scoreofeach;
        return sum / weigth;

    }
    #endregion
}
