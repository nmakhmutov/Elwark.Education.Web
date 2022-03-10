const language = localStorage['ls'];
(async function () {
    await Blazor.start({applicationCulture: language ? JSON.parse(language) : 'en'});
})();

window.Observer = {
    observer: null,
    Initialize: function (component, observerTargetId) {
        let element = document.getElementById(observerTargetId);
        if (element == null)
            throw new Error("The observable target was not found");

        let prevY = 0;
        this.observer = new IntersectionObserver(
            entries => {
                const firstEntry = entries[0];
                const y = firstEntry.boundingClientRect.y;

                if (prevY > y)
                    component.invokeMethodAsync('OnIntersection')

                prevY = y;
            },
            {root: null, rootMargin: '0px', threshold: 0.5}
        );

        this.observer.observe(element);
    }
};
