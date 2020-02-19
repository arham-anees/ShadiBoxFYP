using System;

namespace BusinessLogicLayer {

	public class cBookingRequest {
		private int _Id;
		private cUser _User;
		private cServiceProvider _ServiceProvider;
		private DateTime _Date;
		private DateTime _BookingDate;
		private int _NumberOfGuests;
		private cFunctionTime _FunctionTime;
		private string _Message;

		public int Id
		{
			get => _Id;
			set => _Id = value;
		}

		public int UserId { get; set; }
		public virtual cUser User
		{
			get => _User;
			set => _User = value;
		}

		public int ServiceProviderId { get; set; }
		public virtual cServiceProvider ServiceProvider
		{
			get => _ServiceProvider;
			set => _ServiceProvider = value;
		}

		public DateTime Date
		{
			get => _Date;
			set => _Date = value;
		}

		public DateTime BookingDate
		{
			get => _BookingDate;
			set => _BookingDate = value;
		}

		public int NumberOfGuests
		{
			get => _NumberOfGuests;
			set => _NumberOfGuests = value;
		}

		public int FunctionTimeId { get; set; }
		public virtual cFunctionTime FunctionTime
		{
			get => _FunctionTime;
			set => _FunctionTime = value;
		}

		public string Message
		{
			get => _Message;
			set => _Message = value;
		}
	}
}