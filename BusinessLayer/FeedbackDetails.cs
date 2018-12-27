using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using RentalSystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class FeedbackDetails : IBase<FeedbackModel>
    {
        public OverwatchRentalSystemEntities dbContext => OverwatchRentalSystemEntities.Instance;

        public IEnumerable<FeedbackModel> GetAll()
        {
            IEnumerable<Feedback> list = dbContext.Feedbacks.ToList();
            IEnumerable<FeedbackModel> feedbackList = list.Select(p => Mapper.Map<FeedbackModel>(p));
            return feedbackList;
        }

        public bool Insert(FeedbackModel entity)
        {
            bool status = false;

            try
            {
                Feedback feedbackData = Mapper.Map<Feedback>(entity);
                dbContext.Feedbacks.Add(feedbackData);
                dbContext.SaveChanges();
                status = true;
            }
            catch (Exception e)
            {

                throw e;
            }
            return status;
        }

        public FeedbackModel Update(FeedbackModel entity)
        {
            FeedbackModel model = new FeedbackModel();
            return model;
        }
    }
}
