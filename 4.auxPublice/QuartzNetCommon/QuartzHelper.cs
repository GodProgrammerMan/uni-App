using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System.Collections.Generic;

namespace QuartzNetCommon
{
    public class QuartzHelper
    {

        public static ISchedulerFactory factory = new StdSchedulerFactory();
        /// <summary>
        /// 时间间隔执行任务(重复循环)
        /// </summary>
        /// <typeparam name="T">任务类，必须实现IJob接口</typeparam>
        /// <param name="jobName">工作名称<param>
        /// <param name="group">组名称</param>
        /// <param name="parameter">参数 可为空</param>
        /// <param name="seconds">时间间隔(单位：毫秒)</param>
        public void ExecuteInterval<T>(string jobName, string group, JobDataMapParameter parameter, int seconds) where T : IJob
        {
            IScheduler scheduler = factory.GetScheduler();

            IJobDetail job = JobBuilder.Create<T>()
                .WithIdentity(jobName, group)
                .Build();

            if (parameter != null)
                job.JobDataMap.Put(parameter.Key, parameter.Value);
            ITrigger trigger = TriggerBuilder.Create()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(seconds).RepeatForever())
                .StartNow()
                .Build();

            scheduler.ScheduleJob(job, trigger);

            scheduler.Start();
        }

        /// <summary>
        /// 指定时间执行任务
        /// </summary>
        /// <typeparam name="T">任务类，必须实现IJob接口</typeparam>
        /// <param name="jobName">工作名称<param>
        /// <param name="group">组名称</param>
        /// <param name="parameter">参数 可为空</param>
        /// <param name="cronExpression">cron表达式，即指定时间点的表达式</param>
        /// <summary> 
        public void ExecuteByCron<T>(string jobName, string group, JobDataMapParameter parameter, string cronExpression) where T : IJob
        {
            IScheduler scheduler = factory.GetScheduler();

            IJobDetail job = JobBuilder.Create<T>()
                .WithIdentity(jobName, group)
                .Build();

            //DateTimeOffset startTime = DateBuilder.NextGivenSecondDate(DateTime.Now.AddSeconds(1), 2);
            //DateTimeOffset endTime = DateBuilder.NextGivenSecondDate(DateTime.Now.AddYears(2), 3);

            if (parameter != null)
                job.JobDataMap.Put(parameter.Key, parameter.Value);
            ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
                //.StartAt(startTime).EndAt(endTime)
                .WithCronSchedule(cronExpression)
                .Build();

            scheduler.ScheduleJob(job, trigger);

            scheduler.Start();

        }

        /// <summary>
        /// 更新工作任务(重复循环)
        /// </summary>
        /// <typeparam name="T">任务类，必须实现IJob接口</typeparam>
        /// <param name="jobName">工作名称<param>
        /// <param name="group">组名称</param>
        /// <param name="parameter">参数 可为空</param>
        /// <param name="seconds">时间间隔(单位：毫秒)</param>
        /// <summary> 
        public bool UpdateJob<T>(string jobName, string group, JobDataMapParameter parameter, int seconds) where T : IJob
        {
            IScheduler scheduler = factory.GetScheduler();
            var JobDetail = scheduler.CheckExists(new JobKey(jobName, group));
            if (JobDetail)
            {
                bool isOK = RemoveJob(jobName, group);      //先执行删除之前的工作在重新添加一个工作任务
                if (isOK)
                {
                    IJobDetail job = JobBuilder.Create<T>()
               .WithIdentity(jobName, group)
               .Build();

                    if (parameter != null)
                        job.JobDataMap.Put(parameter.Key, parameter.Value);
                    ITrigger trigger = TriggerBuilder.Create()
                        .WithSimpleSchedule(x => x.WithIntervalInSeconds(seconds).RepeatForever())
                        .StartNow()
                        .Build();

                    scheduler.ScheduleJob(job, trigger);

                    scheduler.Start();
                }

                return true;
            }
            return false;

        }

        /// <summary>
        /// 更新工作任务
        /// </summary>
        /// <typeparam name="T">任务类，必须实现IJob接口</typeparam>
        /// <param name="jobName">工作名称<param>
        /// <param name="group">组名称</param>
        /// <param name="parameter">参数 可为空</param>
        /// <param name="cronExpression">cron表达式，即指定时间点的表达式</param>
        /// <summary> 
        public bool UpdateJob<T>(string jobName, string group, JobDataMapParameter parameter, string cronExpression) where T : IJob
        {
            IScheduler scheduler = factory.GetScheduler();
            var JobDetail = scheduler.GetJobDetail(new JobKey(jobName, group)); 
            if (JobDetail != null)
            {
                bool isOK = RemoveJob(jobName, group);      //先执行删除之前的工作在重新添加一个工作任务
                if (isOK)
                {
                    IJobDetail job = JobBuilder.Create<T>()
                        .WithIdentity(jobName, group)
                        .Build();

                    if (parameter != null)
                        job.JobDataMap.Put(parameter.Key, parameter.Value);
                    ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
                        .WithCronSchedule(cronExpression)
                        .Build();

                    scheduler.ScheduleJob(job, trigger);

                    scheduler.Start();
                }

                return true;
            }
            return false;

        }

        /// <summary>
        /// 删除一个工作任务
        /// </summary>  
        /// <param name="jobName">工作名称<param> 
        /// <param name="group">组<param> 
        /// <summary> 
        public bool RemoveJob(string jobName, string group)
        {
            IScheduler scheduler = factory.GetScheduler();
            return scheduler.DeleteJob(new JobKey(jobName, group));
        }

        /// <summary>
        /// 删除多个工作任务
        /// </summary>  
        /// <param name="key"><param> 
        /// <summary> 
        public bool RemoveListJob(IList<JobKey> key)
        {
            IScheduler scheduler = factory.GetScheduler();
            return scheduler.DeleteJobs(key);
        }


        /// <summary>
        /// 暂停一个工作任务
        /// </summary>  
        /// <param name="jobName">工作名称<param> 
        /// <param name="group">组<param> 
        /// <summary> 
        public void PauseJob(string jobName, string group)
        {
            IScheduler scheduler = factory.GetScheduler();
            scheduler.PauseJob(new JobKey(jobName, group));
        }


        /// <summary>
        /// 暂停多个工作任务
        /// </summary> 
        /// <param name="parameter">参数 可为空</param>
        /// <param name="jobName">工作名称<param> 
        /// <summary> 
        public void PauseListJob(GroupMatcher<JobKey> matcher)
        {
            IScheduler scheduler = factory.GetScheduler();
            scheduler.PauseJobs(matcher);
        }

        /// <summary>
        /// 暂停所有工作任务
        /// </summary> 
        /// <param name="parameter">参数 可为空</param>
        /// <param name="jobName">工作名称<param> 
        /// <summary> 
        public void PauseAll()
        {
            IScheduler scheduler = factory.GetScheduler();
            scheduler.PauseAll();
        }


        /// <summary>
        /// 恢复一个工作任务
        /// </summary>  
        /// <summary> 
        public void ResumeJob(string jobName, string group)
        {
            IScheduler scheduler = factory.GetScheduler();
            scheduler.ResumeJob(new JobKey(jobName, group));
        }


        /// <summary>
        /// 恢复多个工作任务
        /// </summary>  
        /// <summary> 
        public void ResumeListJob(GroupMatcher<JobKey> matcher)
        {
            IScheduler scheduler = factory.GetScheduler();
            scheduler.ResumeJobs(matcher);
        }

        /// <summary>
        /// 恢复所有工作任务
        /// </summary>  
        /// <summary> 
        public void ResumeAll()
        {
            IScheduler scheduler = factory.GetScheduler();
            scheduler.ResumeAll();
        }

        /// <summary>
        /// 关闭任务调度
        /// </summary>
        /// <param name="waitForJobsToComplete"> 是否等待任务完成在关闭</param>
        public void Shutdown(bool waitForJobsToComplete = false)
        {
            IScheduler scheduler = factory.GetScheduler();
            scheduler.Shutdown(waitForJobsToComplete);
        }

        /// <summary>
        /// 是否存在该工作任务
        /// </summary>  
        /// <summary> 
        public bool Exists(string jobName, string group)
        {
            IScheduler scheduler = factory.GetScheduler();
            return scheduler.CheckExists(new JobKey(jobName, group));
        }


        /// <summary>
        /// 获取任务组下所有工作的Keys
        /// </summary>  
        /// <summary> 
        public List<JobKey> GetJobKeys(string group)
        {
            IScheduler scheduler = factory.GetScheduler();
            var GroupList = GroupMatcher<JobKey>.GroupEquals(group);
            var JobList = scheduler.GetJobKeys(GroupList);
            var NewJobList = new List<JobKey>();
            foreach (var item in JobList)
            {
                NewJobList.Add(new JobKey(item.Name, item.Group));
            }
            return NewJobList;
        }



    }

    #region 任务执行例
    //public class MyJob : IJob
    //{
    //    public void Execute(IJobExecutionContext context)
    //    {
    //        Console.WriteLine("executed..." + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
    //    }
    //} 
    #endregion
}