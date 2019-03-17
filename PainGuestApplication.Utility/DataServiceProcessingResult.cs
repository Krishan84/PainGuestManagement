using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Utility
{
    public class DataServiceProcessingResult
    {
        private ProcessingError _error = new ProcessingError("-1", "", "");
        public bool Success { get; set; }
        public ProcessingError Error
        {
            get { return _error; }
            set { _error = value; }
        }
        public bool IsFatal()
        {
            return !Success && Error.IsFatal;
        }
    }

    public class DataServiceProcessingResult<T> : DataServiceProcessingResult
    {
        public T Data;
    }
    public class ProcessingError
    {
        public string ErrorCode { get; set; }
        public string UserMessage { get; set; }
        public string AdminMessage { get; set; }
        public string UserHelp { get; set; }
        public bool IsFatal { get; set; }
        public ProcessingError(string errorCode, string userMessage, string userHelp, bool isFatal = false, string adminMessage = null)
        {
            ErrorCode = errorCode;
            UserMessage = userMessage;
            UserHelp = userHelp;
            IsFatal = isFatal;
            AdminMessage = adminMessage;
        }
    }


    public class DataAccessError
    {
        public string UserMessage { get; set; }
        public string ErrorCode { get; set; }
        public bool IsFatal { get; set; }
        public string AdminMessage { get; set; }
        public string UserDisplayMessage { get; set; }
        public DataAccessError(string userMessage, string errorCode = "0", bool isFatal = false, string adminMesssage = "", string userDisplayMessage = "")
        {
            UserMessage = userMessage;
            ErrorCode = errorCode;
            IsFatal = isFatal;
            AdminMessage += adminMesssage;
            UserDisplayMessage = userDisplayMessage;
        }

        public DataAccessError(ProcessingError processingError)
        {
            UserMessage = (processingError.UserMessage + " " + processingError.UserHelp).Trim();
            ErrorCode = processingError.ErrorCode;
            IsFatal = processingError.IsFatal;
            AdminMessage = "";
        }
        public ProcessingError ToProcessingError()
        {
            return new ProcessingError(ErrorCode, UserMessage, "", IsFatal);
        }
    }

    public class DataAccessResult
    {
        private DataAccessError _error = new DataAccessError("");
        public bool Success { get; set; }
        public DataAccessError Error
        {
            get { return _error; }
            set { _error = value; }
        }
        public bool IsFatal()
        {
            if (!Success && Error.IsFatal)
            {
                return true;
            }
            return false;
        }

        public DataServiceProcessingResult ConvertToDSPR(ProcessingError error)
        {
            var result = new DataServiceProcessingResult { Success = Success };
            if (!Success)
            {
                result.Error = error;
            }
            return result;
        }
    }



    public class DataAccessResult<TReturnedObject> : DataAccessResult
    {
        public TReturnedObject ReturnedObject { get; set; }
        public DataServiceProcessingResult<TReturnedObject> ConvertToDSPR(ProcessingError error)
        {
            var result = new DataServiceProcessingResult<TReturnedObject> { Success = Success, Data = ReturnedObject };
            if (!Success)
            {
                result.Error = error;
            }
            return result;
        }
    }
    public class PagedDataAccessResult<TReturnedObject> : DataAccessResult<TReturnedObject>
    {
        public TReturnedObject ReturnedObject { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
        public int Count { get; set; }
        public int CurrentPage { get; set; }
    }
}
