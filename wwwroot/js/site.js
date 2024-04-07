$(document).ready(function () {
    $('.banner-home').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        autoHeight: true,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 1
            },
            1000: {
                items: 1,
                nav: true,
            }
        }
    })
    $('.list-news-home').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        autoHeight: true,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 1
            },
            1000: {
                items: 3,
                nav: true,
            }
        }
    })
});