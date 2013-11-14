var controls = (function () {

    function hidePrev(item) {
        var prev = item.previousElementSibling;
        while (prev) {
            var sublist = prev.querySelector("ul");
            if (sublist) {
                sublist.style.display = "none";
            }
            prev = prev.previousElementSibling;
        }
    };

    function hideNext(item) {
        var next = item.nextElementSibling;
        while (next) {
            var sublist = next.querySelector("ul");
            if (sublist) {
                sublist.style.display = "none";
            }
            next = next.nextElementSibling;
        }
    };

    function Accordion(selector) {
        var items = [];
        var accItem = document.querySelector(selector);

        accItem.addEventListener("click",
            function (ev) {
                if (!ev) {
                    ev = window.event;
                }

                ev.stopPropagation();
                ev.preventDefault();

                //<a>
                var clickedItem = ev.target;
                if (!(clickedItem instanceof HTMLAnchorElement)) {
                    return;
                }

                hidePrev(clickedItem.parentNode);
                hideNext(clickedItem.parentNode);

                var sublist = clickedItem.nextElementSibling;

                if (!sublist) {
                    return;
                }
                if (sublist.style.display === "none") {
                    sublist.style.display = "";
                }
                else {
                    sublist.style.display = "none";
                }

            }, false);

        var itemsList = document.createElement("ul");

        this.add = function (title) {
            var newItem = new Item(title);
            items.push(newItem);
            return newItem;
        };

        this.render = function () {
            while (accItem.firstChild) {
                accItem.removeChild(accItem.firstChild);
            }
			
            var thisList = itemsList.cloneNode(true);

            var len = items.length;
            for (var i = 0; i < len; i += 1) {
                var domItem = items[i].render();
                thisList.appendChild(domItem);
            }
            accItem.appendChild(thisList);
            return this;
        };
    };

    function Item(title) {
        var items = [];

        this.add = function (title) {
            var newItem = new Item(title);
            items.push(newItem);
            return newItem;
        };

        this.render = function () {
            var itemNode = document.createElement("li");
            var itemTitle = document.createElement("a");
            itemNode.appendChild(itemTitle);
            itemTitle.innerHTML = title;

            if (items.length > 0) {
                var subList = document.createElement("ul");
                subList.style.display = "none";
                var len = items.length;
                for (var i = 0; i < len; i += 1) {
                    var subItems = items[i].render();
                    subList.appendChild(subItems);
                }
                itemNode.appendChild(subList);
            }
            return itemNode;
        };
    };

    return {
        getAccordion: function (selector) {
            return new Accordion(selector);
        }
    };
}());