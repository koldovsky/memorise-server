
namespace MemoBll.Logic
{
    public enum Repeat
    {
        NoRepeat = 0,
        OneRepeat = 1,
        TwoRepeat = 2,
        ThreeRepeat = 3,
        TourRepeat = 4
    }

    public enum RepeatIn
    {
        FirstRepeatInHours = 12,
        SecondRepeatInHours = 48,
        ThirdRepeatInHours = 24 * 6,
        FourthRepeatInHours = 24 * 20,
    }

    public enum DeadlineForRepeatIn
    {
        FirstDeadlineForRepeatInHours = 24,
        SecondDeadlineForRepeatInHours = 72,
        ThirdDeadlineForRepeatInHours = 24 * 8,
        FourthDeadlineForRepeatInHours = 24 * 24
    }
}
