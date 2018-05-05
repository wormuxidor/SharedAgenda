window.SessionTimeout = (function () {
    var _timeLeft, _popupTimer, _countDownTimer;

    var stopTimers = function () {
        window.clearTimeout(_popupTimer);
        window.clearTimeout(_countDownTimer);
    };

    var updateCountDown = function () {
        var min = Math.floor(_timeLeft / 60);
        var sec = _timeLeft % 60;
        if (sec < 10)
            sec = "0" + sec;

        document.getElementById("CountDownHolder").innerHTML = min + ":" + sec;

        if (_timeLeft > 0) {
            _timeLeft--;
            _countDownTimer = window.setTimeout(updateCountDown, 1000);
        } else {
            window.location = <%= QuotedTimeOutUrl %>;
        }
    };

    var showPopup = function () {
        _timeLeft = 60;
        updateCountDown();
        ClientTimeoutPopup.Show();
    };

    var schedulePopup = function () {
        stopTimers();
        _popupTimer = window.setTimeout(showPopup, <%= PopupShowDelay %>);
    };

    var sendKeepAlive = function () {
        stopTimers();
        ClientTimeoutPopup.Hide();
        ClientKeepAliveHelper.PerformCallback();
    };

    return {
        schedulePopup: schedulePopup,
        sendKeepAlive: sendKeepAlive
    };

})();