using System;
using Microsoft.SPOT;

namespace CTRE.Phoenix
{
    public class CANifierFaults
    {
        //!< True iff any of the above flags are true.
        bool HasAnyFault() {
		return false;
    }
    int ToBitfield() {
		int retval = 0;
		return retval;
	}

    CANifierFaults(int bits){}
};
}
