namespace GeoObservables.Api.Business.Models
{
    public class HFlowdataModel
    {
        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of HFlowdataModel class.
        /// </summary>
        public HFlowdataModel()
        {
        }

        public HFlowdataModel(double longi, double lat, double height, double hflow, int idorigin, string description = "No description")
        {
            this.Long = longi;
            this.Lat = lat;
            this.Height = height;
            this.Hflow = hflow;
            this.idOrigin = idorigin;
            this.Description = description;
        }

        #endregion

        public int Id { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public double Height { get; set; }
        public double Hflow { get; set; }
        public int idOrigin { get; set; }
        public string Description { get; set; }
        public DateTime Datacreated { get; set; }
        public DateTime Datamodified { get; set; }
        public int idUserCreate { get; set; }
        public virtual OriginModel Origin { get; set; }
        public virtual UsersModel User { get; set; }
    }
}
