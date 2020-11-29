﻿using System;
using System.Linq.Expressions;
using Hangfire;
using Core.Interfaces.Services;

namespace Infrastructure.Services
{
    /// <summary>
    /// A wrapper around the Hangfire Job-API to abstract the concrete Hangfire
    /// implementation away from upper layers within the Clean Architecture
    /// </summary>
    public sealed class JobQueueService : IJobQueueService
    {
        /// <summary>
        /// Creates a new fire-and-forget job based on a given method call expression
        /// </summary>
        /// <param name="methodCall"></param>
        /// <returns></returns>
        public string Enqueue<T>(Expression<Action<T>> methodCall)
        {
            return BackgroundJob.Enqueue(methodCall);
        }

        /// <summary>
        /// Schedule a job to run every X hours
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="methodCall"></param>
        /// <param name="everyHours"></param>
        public void RecurringJobHourly<T>(string id, Expression<Action<T>> methodCall, int everyHours)
        {
            RecurringJob.AddOrUpdate(id, methodCall, $"0 */{everyHours} * * *");
        }
    }
}
