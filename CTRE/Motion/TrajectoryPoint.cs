using System;
using Microsoft.SPOT;

namespace CTRE.Phoenix.Motion
{
    public class TrajectoryPoint
    {
        /**
         * Duration to apply to a particular trajectory pt.
         * This time unit is ADDED to the existing base time set by
         * configMotionProfileTrajectoryPeriod().
         */
        public enum TrajectoryDuration
        {
            TrajectoryDuration_0ms = 0,
            TrajectoryDuration_5ms = 5,
            TrajectoryDuration_10ms = 10,
            TrajectoryDuration_20ms = 20,
            TrajectoryDuration_30ms = 30,
            TrajectoryDuration_40ms = 40,
            TrajectoryDuration_50ms = 50,
            TrajectoryDuration_100ms = 100,
        };

        public double position; // !< The position to servo to.
        public double velocity; // !< The velocity to feed-forward.
        public double headingDeg; // !< Not used.  Use auxiliaryPos instead.  @see auxiliaryPos
        public double auxiliaryPos; // !< The position for auxiliary PID to target.

        /**
         * Which slot to get PIDF gains. PID is used for position servo. F is used
         * as the Kv constant for velocity feed-forward. Typically this is hard-coded
         * to a particular slot, but you are free to gain schedule if need be.
         * Choose from [0,3]
         */
        public int profileSlotSelect0;

        /**
         * Which slot to get PIDF gains for auxiliary PId.
         * This only has impact during MotionProfileArc Control mode.
         * Choose from [0,1].
         */
        public int profileSlotSelect1;

        /**
         * Set to true to signal Talon that this is the final point, so do not
         * attempt to pop another trajectory point from out of the Talon buffer.
         * Instead continue processing this way point. Typically the velocity member
         * variable should be zero so that the motor doesn't spin indefinitely.
         */
        public bool isLastPoint;
        /**
         * Set to true to signal Talon to zero the selected sensor. When generating
         * MPs, one simple method is to make the first target position zero, and the
         * final target position the target distance from the current position. Then
         * when you fire the MP, the current position gets set to zero. If this is
         * the intent, you can set zeroPos on the first trajectory point.
         *
         * Otherwise you can leave this false for all points, and offset the
         * positions of all trajectory points so they are correct.
         */
        public bool zeroPos;

        /**
         * Duration to apply this trajectory pt.
         * This time unit is ADDED to the existing base time set by
         * configMotionProfileTrajectoryPeriod().
         */
        public TrajectoryDuration timeDur;
    }
}
