
namespace Life.API.Helpers
{
    public static class ExceptionHelper
    {
        public const string ArgumentOutOfBound = "Argument out of bound";
        public const string ArgumentOutOfRangeExceptionForCell = "Row and Column size must be greater than zero";
        public const string ArgumentNullExceptionForCell = "Cell doesn't have data for required indexes";
        public const string ArgumentOutOfRangeExceptionForRow = "Invalid Index value: must be greater than or equal to zero and less than Row count";
        public const string ArgumentNullExceptionForUnreachableCoordinates = "Cannot find reachable co-ordinates";
        public const string InvalidInput = "Argument out of bound";
     
    }
}
