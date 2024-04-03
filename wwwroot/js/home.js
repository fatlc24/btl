$(document).ready(
    function () {
        let owl = $('#manualsct');
        owl.owlCarousel({
            margin: 0,
            autoplay: true,
            autoplayTimeout: 5000,
            nav: false,
            loop: true,
            dots: true,
            dotsData: true,
            pagination: false,
            margin: 0,
            responsive: {
                0: { items: 1 },
                600: { items: 1 },
                1000: { items: 1 }
            }
        })
    }
)