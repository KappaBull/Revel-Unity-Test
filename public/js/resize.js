var canvas;
var timer = 0;

//サイズ変更処理
function resize() {
    canvas.setAttribute('width', window.innerWidth);
    canvas.setAttribute('height', window.innerHeight);
}

window.onload = function () {
    canvas = document.getElementById('#canvas');
    resize();
};

//ブラウザの大きさが変わった時に行う処理
(function () {
    var timer = 0;
    window.onresize = function () {
        if (timer > 0) {
            clearTimeout(timer);
        }

        timer = setTimeout(function () {
            resize();
        }, 200);
    };
}());