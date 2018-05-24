using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadSolution.Model
{
    /// <summary>
    /// 实体类Problem 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Problem
    {
        public Problem()
        { }
        #region Model
        private string _problemid;
        private string _bigclass;
        private string _smallclass;
        private string _title;
        private string _authorid;
        private string _address;
        private string _description;
        private string _problemshot;
        private string _uploaddate;
        private DateTime _uploadtime;
        private string _road;
        private decimal _lat;
        private decimal _lng;
        private bool _ishandled;
        private bool _isreviewed;
        private string _reviewshot;
        private string _handledate;
        private DateTime _handletime;
        private string _reviewdate;
        private DateTime _reviewtime;
        private User _user;
        public User User
        {
            set { _user = value; }
            get { return _user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProblemID
        {
            set { _problemid = value; }
            get { return _problemid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BigClass
        {
            set { _bigclass = value; }
            get { return _bigclass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SmallClass
        {
            set { _smallclass = value; }
            get { return _smallclass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuthorID
        {
            set { _authorid = value; }
            get { return _authorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProblemShot
        {
            set { _problemshot = value; }
            get { return _problemshot; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UploadDate
        {
            set { _uploaddate = value; }
            get { return _uploaddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UploadTime
        {
            set { _uploadtime = value; }
            get { return _uploadtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Road
        {
            set { _road = value; }
            get { return _road; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Lat
        {
            set { _lat = value; }
            get { return _lat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Lng
        {
            set { _lng = value; }
            get { return _lng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsHandled
        {
            set { _ishandled = value; }
            get { return _ishandled; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsReviewed
        {
            set { _isreviewed = value; }
            get { return _isreviewed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReviewShot
        {
            set { _reviewshot = value; }
            get { return _reviewshot; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HandleDate
        {
            set { _handledate = value; }
            get { return _handledate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime HandleTime
        {
            set { _handletime = value; }
            get { return _handletime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReviewDate
        {
            set { _reviewdate = value; }
            get { return _reviewdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ReviewTime
        {
            set { _reviewtime = value; }
            get { return _reviewtime; }
        }
        #endregion Model
    }
}

