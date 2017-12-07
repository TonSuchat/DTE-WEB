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

function DiffStartStopDate(startDate, stopDate, elemId) {
    if (!startDate || !stopDate) {
        $('#' + elemId).val(0);
        return;
    }
    
    startDate = new Date(startDate);
    stopDate = new Date(stopDate);

    var diff = (stopDate - startDate);
    var diffMins = Math.round(diff / 60000);
    console.log(diffMins);
    $('#' + elemId).val(diffMins);
}

function GetDateFromServerDate(date) {
    if (date == null || !date) return null;
    var year = date.substring(0, 4);
    var month = date.substring(4, 6) - 1;
    var day = date.substring(6, 8);
    var hour = date.substring(8, 10);
    var minute = date.substring(10, 12);
    return new Date(year, month, day, hour, minute, 0);
}

function InitialDateTimePicker(elemId, inputDate) {
    if (inputDate == null) $('#' + elemId).datetimepicker({ format: 'D/MM/YYYY HH:mm' });
    else $('#' + elemId).datetimepicker({ format: 'D/MM/YYYY HH:mm', date: inputDate });
}