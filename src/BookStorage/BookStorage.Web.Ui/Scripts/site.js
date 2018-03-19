$(function () {

    var BookModel = function(data) {
        this.id = ko.observable(data.Id);
        this.title = ko.observable(data.Title);
        this.authors = ko.observable(data.Authors);
        this.publishingHouse = ko.observable(data.PublishingHouse);
        this.yearOfPublishing = ko.observable(data.YearOfPublishing);
        this.edit = function (item) {

        }
    }

    var PageModel = new function() {
        this.books = ko.observableArray();
    };

    function apiRequest(httpMethod, url, callback) {
        $.ajax("/api/books" + (url ? "/" + url : ""), {
            type: httpMethod,
            success: callback
        });
    };

    function getAllBooks() {

        apiRequest("GET", "", function (data) {

            PageModel.books.removeAll();

            for (var i = 0; i < data.length; i++) {
                PageModel.books.push(new BookModel(data[i]));
            }
        });
    }

    getAllBooks();
    ko.applyBindings(PageModel);
});