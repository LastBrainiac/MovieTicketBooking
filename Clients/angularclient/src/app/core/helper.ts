import { ScreeningData } from "../models/screeningData";

export class Helper {

    private static currentDay(index: number): Date {
        const currentDate = new Date();
        currentDate.setDate(currentDate.getDate() + index);
        return currentDate;
    }

    static getScreeningData(): ScreeningData[] {
        return [...Array(7).keys()]
            .map(index => {
                return (
                    {
                        shortDate: this.currentDay(index).toISOString().split('T')[0],
                        day: this.currentDay(index).toLocaleDateString('en-US', { day: 'numeric' }),
                        dayName: this.currentDay(index).toLocaleDateString('en-US', { weekday: 'long' })
                    }
                )
            });
    }

    static getLongDate(): Intl.DateTimeFormat {
        return new Intl.DateTimeFormat('en', {
            timeStyle: undefined,
            dateStyle: "long"
        });
    }

    static getLongDateShortTime(): Intl.DateTimeFormat {
        return new Intl.DateTimeFormat('en', {
            timeStyle: "short",
            dateStyle: "long",
            hour12: false
        });
    }
}
