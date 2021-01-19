Blazor.start({applicationCulture: localStorage['language']});

window.Observer = {
    observer: null,
    Initialize: function (component, observerTargetId) {
        let element = document.getElementById(observerTargetId);
        if (element == null)
            throw new Error("The observable target was not found");

        this.observer = new IntersectionObserver(
            e => component.invokeMethodAsync('OnIntersection'),
            {root: null, rootMargin: '0px', threshold: 0.5}
        );

        this.observer.observe(element);
    }
};