using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_SERVICE_CLIENT_HOST.Models.StatusCodes
{
    public enum BookingCodes { INVALID, VALID, REQ_MOVE_IN, APPROVED, CANCELLED, NOT_APPROVED}
    public enum AccreditationCodes {APPROVED, DISAPPROVED, PENDING, NOT_ACCREDITTED, ACCREDITTED}
    public enum InspectionCodes {PASSED, FAILED, PENDING}

    class Codes
    {
    }
}
