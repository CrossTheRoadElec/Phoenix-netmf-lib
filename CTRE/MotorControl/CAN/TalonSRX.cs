﻿using System;
using Microsoft.SPOT;

namespace CTRE.Phoenix.MotorControl.CAN
{
    public class TalonSRX : BaseMotorController, IMotorControllerEnhanced
    {
        SensorCollection _sensorColl;

        // : CANBusDevice TODO CLEANUP and package CAN stuff  /* all CAN stuff here */
        [Obsolete("Use single parameter constructor instead.")]
        public TalonSRX(int deviceNumber, bool externalEnable = false) : base(deviceNumber | 0x02040000, externalEnable)
        {
            _sensorColl = new SensorCollection(_ll);
        }

        public TalonSRX(int deviceNumber) : base(deviceNumber | 0x02040000, false)
        {
            _sensorColl = new SensorCollection(_ll);
        }

        /**
	     * Sets the period of the given status frame.
	     *
	     * User ensure CAN Bus utilization is not high.
	     *
	     * This setting is not persistent and is lost when device is reset.
	     * If this is a concern, calling application can use HasReset()
	     * to determine if the status frame needs to be reconfigured.
	     *
	     * @param frame
	     *            Frame whose period is to be changed.
	     * @param periodMs
	     *            Period in ms for the given frame.
	     * @param timeoutMs
	     *            Timeout value in ms. If nonzero, function will wait for
	     *            config success and report an error if it times out.
	     *            If zero, no blocking or checking is performed.
	     * @return Error Code generated by function. 0 indicates no error.
	     */
        new public ErrorCode SetStatusFramePeriod(StatusFrameEnhanced frame, int periodMs, int timeoutMs)
        {
            return base.SetStatusFramePeriod(frame, periodMs, timeoutMs);
        }
        /**
         * Gets the period of the given status frame.
         *
         * @param frame
         *            Frame to get the period of.
         * @param timeoutMs
         *            Timeout value in ms. If nonzero, function will wait for
         *            config success and report an error if it times out.
         *            If zero, no blocking or checking is performed.
         * @return Period of the given status frame.
         */
        public int GetStatusFramePeriod(StatusFrameEnhanced frame, int timeoutMs)
        {
            int periodMs;
            base.GetStatusFramePeriod(frame,out periodMs, timeoutMs);
            return periodMs;
        }


        /**
	 * Configures a limit switch for a local/remote source.
	 *
	 * For example, a CAN motor controller may need to monitor the Limit-R pin
	 * of another Talon, CANifier, or local Gadgeteer feedback connector.
	 *
	 * If the sensor is remote, a device ID of zero is assumed.
	 * If that's not desired, use the four parameter version of this function.
	 *
	 * @param type
	 *            Limit switch source.
	 *            User can choose between the feedback connector, remote Talon SRX, CANifier, or deactivate the feature.
	 * @param normalOpenOrClose
	 *            Setting for normally open, normally closed, or disabled. This setting
	 *            matches the web-based configuration drop down.
	 * @param timeoutMs
	 *            Timeout value in ms. If nonzero, function will wait for
	 *            config success and report an error if it times out.
	 *            If zero, no blocking or checking is performed.
	 * @return Error Code generated by function. 0 indicates no error.
	 */
        public ErrorCode ConfigForwardLimitSwitchSource(LimitSwitchSource type, LimitSwitchNormal normalOpenOrClose,
                int timeoutMs)
        {

            return _ll.ConfigForwardLimitSwitchSource(type, normalOpenOrClose, 0x00000000, timeoutMs);
        }
        /**
         * Configures a limit switch for a local/remote source.
         *
         * For example, a CAN motor controller may need to monitor the Limit-R pin
         * of another Talon, CANifier, or local Gadgeteer feedback connector.
         *
         * If the sensor is remote, a device ID of zero is assumed. If that's not
         * desired, use the four parameter version of this function.
         *
         * @param type
         *            Limit switch source. @see #LimitSwitchSource User can choose
         *            between the feedback connector, remote Talon SRX, CANifier, or
         *            deactivate the feature.
         * @param normalOpenOrClose
         *            Setting for normally open, normally closed, or disabled. This
         *            setting matches the web-based configuration drop down.
         * @param timeoutMs
         *            Timeout value in ms. If nonzero, function will wait for config
         *            success and report an error if it times out. If zero, no
         *            blocking or checking is performed.
         * @return Error Code generated by function. 0 indicates no error.
         */
        public ErrorCode ConfigReverseLimitSwitchSource(LimitSwitchSource type, LimitSwitchNormal normalOpenOrClose,
                int timeoutMs)
        {
            return _ll.ConfigReverseLimitSwitchSource(type, normalOpenOrClose, 0x00000000, timeoutMs);
        }

        //------ Current Lim ----------//
        public ErrorCode ConfigPeakCurrentLimit(int amps, int timeoutMs = 0)
        {
            return _ll.ConfigPeakCurrentLimit(amps, timeoutMs);
        }
        public ErrorCode ConfigPeakCurrentDuration(int milliseconds, int timeoutMs = 0)
        {
            return _ll.ConfigPeakCurrentDuration(milliseconds, timeoutMs);
        }
        public ErrorCode ConfigContinuousCurrentLimit(int amps, int timeoutMs = 0)
        {
            return _ll.ConfigContinuousCurrentLimit(amps, timeoutMs);
        }
        public void EnableCurrentLimit(bool enable)
        {
            _ll.EnableCurrentLimit(enable);
        }
        //------ Local sensor collection ----------//
        public SensorCollection SensorCollection { get { return _sensorColl; } }
    }
}




