using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using DayOne.Entities;

namespace DayOne.IoObjects
{
    public  class ShareableContent
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime UpdateAt { get; set; }

        public string UserName { get; set; }

        public int LoveCount { get; set; }

        public bool IsMyPraised { get; set; }

        public ShareableContent() { }

        public ShareableContent(ShareInfo shareInfo)
        {
            Id = shareInfo.Id;
            if (shareInfo.User != null)
            {
                UserName = shareInfo.User.UserName;
            }

            UpdateAt = shareInfo.UpdateAt;
            LoveCount = shareInfo.LoveCount;
            IsMyPraised = shareInfo.IsMyPraised;

            if (shareInfo is DayPlan)
            {
                var plan = shareInfo as DayPlan;

                if (plan.Content != null)
                {
                    Title = plan.Content.Length < 10 ? plan.Content : plan.Content.Substring(0, 10);
                }
                var sb = new StringBuilder();
                sb.Append("开始时间: ").Append(plan.CreateAt).Append("<br />\n");

                if (plan.ExpectEndAt != default(DateTime))
                {
                    sb.Append("预计完成: ").Append(plan.ExpectEndAt).Append("<br />\n");
                }
                sb.Append("是否完成: ").Append(plan.IsCompleted ? "是" : "否").Append("<br />\n<br />\n");
                sb.Append(plan.Content);

                Content = sb.ToString();
            }
            else if (shareInfo is OneNote)
            {
                var note = (OneNote) shareInfo;

                Title = note.Title;
                Content = note.Content;
            }
        }

        public ShareableContent(ShareList shareInfo)
        {
            Id = shareInfo.Id;
            UserName = shareInfo.User.UserName;
            
            UpdateAt = shareInfo.ShareAt;

            if (shareInfo.Note != null)
            {
                Title = shareInfo.Note.Title;
                Content = shareInfo.Note.Content;
                LoveCount = shareInfo.Note.LoveCount;
            }
            else if (shareInfo.Plan != null)
            {
                var plan = shareInfo.Plan;

                if (plan.Content != null)
                {
                    Title = plan.Content.Length < 10 ? plan.Content : plan.Content.Substring(0, 10);
                }
                var sb = new StringBuilder();
                sb.Append("开始时间: ").Append(plan.CreateAt).Append("<br />\n");

                if (plan.ExpectEndAt != default(DateTime))
                {
                    sb.Append("预计完成: ").Append(plan.ExpectEndAt).Append("<br />\n");
                }
                sb.Append("是否完成: ").Append(plan.IsCompleted ? "是" : "否").Append("<br />\n<br />\n");
                sb.Append(plan.Content);

                Content = sb.ToString();

                LoveCount = shareInfo.Plan.LoveCount;
            }
            else
            {
                throw new InvalidProgramException("invalid share data type");
            }
        }
    }
}
