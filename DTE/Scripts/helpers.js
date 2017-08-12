function GetStringFormatByDate(selectedDate) {
    if (selectedDate == null) return "";

    var year = selectedDate.getFullYear();

    var month = (1 + selectedDate.getMonth()).toString();
    month = month.length > 1 ? month : '0' + month;

    var day = selectedDate.getDate().toString();
    day = day.length > 1 ? day : '0' + day;

    var hour = selectedDate.getHours().toString();
    hour = hour.length > 1 ? hour : '0' + hour;

    var minute = selectedDate.getMinutes().toString();
    minute = minute.length > 1 ? minute : '0' + minute;

    var result = year + month + day + hour + minute + '00';
    return result;
}