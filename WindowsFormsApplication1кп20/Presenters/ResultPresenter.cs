using System;
using System.Collections.Generic;
using System.Linq;
using WindowsFormsApplication1кп20.Models;
using WindowsFormsApplication1кп20.Utils;

namespace WindowsFormsApplication1кп20.Presenters
{
    public class ResultPresenter : PresenterBase
    {
        private readonly List<UserResult> _dataSource = new List<UserResult>();

        public ResultPresenter(ISecurityManager securityManager) : base(securityManager)
        {
            //
        }

        public List<string> DataSource
        {
            get { return _dataSource.OrderBy(ur => ur.ElapsedTime).Select(ur => ur.ToString()).ToList(); }
        }

        public void AddResult(TimeSpan elapsedTime)
        {
            _dataSource.Add(new UserResult
            {
                ElapsedTime = elapsedTime,
                UserName = SecurityManager.CurrentUser
            });
        }
    }
}