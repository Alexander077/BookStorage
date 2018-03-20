$(function () {

    var HomeModel = new function () {
        var self = this;
        this.books = ko.observableArray();
        this.isEditMode = ko.observable(false);
        this.editItem = ko.observable();
        this.isCreateMode = ko.observable(false);
        this.itemToCreate = ko.observable();


        this.createMode = function (createModeEnabled) {

            if (createModeEnabled){
                this.itemToCreate(new BookModel(null));
            }

            this.isCreateMode(createModeEnabled);
        }

        this.createBook = function () {

            $.ajax({
                method: "POST",
                url: "/api/books/",
                data: {
                    Title: this.itemToCreate().title(),
                    Authors: this.itemToCreate().authors(),
                    PublishingHouse: this.itemToCreate().publishingHouse(),
                    YearOfPublishing: this.itemToCreate().yearOfPublishing()
                }
            })
            .done(function (data, textStatus, jqXHR) {
                    self.books.push(self.itemToCreate());
                    self.itemToCreate(null);
                    alert("Book successfully added");
                })
            .fail(function (jqXHR, textStatus, errorThrown) {
                alert("Error while creating book: " + textStatus);
            })
            .always(function () {
                self.isCreateMode(false);
            });
        }

        this.editMode = function (editEnabled) {

            if (editEnabled){
                self.editItem(this);
            } 

            self.isEditMode(editEnabled);
        }

        this.confirmEdit = function () {

            $.ajax({
                method: "PUT",
                url: "/api/books/" + this.editItem().id(),
                data: {
                    Id: this.editItem().id(),
                    Title: this.editItem().title(),
                    Authors: this.editItem().authors(),
                    PublishingHouse: this.editItem().publishingHouse(),
                    YearOfPublishing: this.editItem().yearOfPublishing()
                }
            })
            .done(function (data, textStatus, jqXHR) {
                alert("Book saved");
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                alert("Error: " + textStatus);
            }).always(function () {
                self.isEditMode(false);
            });
        }

        this.deleteBook = function () {

            if (confirm("Are you sure that you want to delete this book?")) {
                $.ajax({
                        method: "DELETE",
                        url: "/api/books/" + this.editItem().id()
                    })
                    .done(function(data, textStatus, jqXHR) {
                        self.books.remove(self.editItem());
                        alert("Book deleted");
                    })
                    .fail(function(jqXHR, textStatus, errorThrown) {
                        alert("Error while deleting book: " + textStatus);
                    })
                    .always(function() {
                        self.isEditMode(false);
                    });
            }
        }

        this.getAllBooks = function getAllBooks() {

            $.ajax({
                method: "GET",
                url: "/api/books/"
            })
               .done(function (data, textStatus, jqXHR) {

                   self.books.removeAll();

                   for (var i = 0; i < data.length; i++)
                   {
                       self.books.push(new BookModel(data[i]));
                   }
               })
               .fail(function (jqXHR, textStatus, errorThrown) {
                   alert("Error: " + textStatus);
               });
        }
    };

    var BookModel = function (data) {

        this.id = ko.observable();
        this.title = ko.observable();
        this.authors = ko.observable();
        this.publishingHouse = ko.observable();
        this.yearOfPublishing = ko.observable();

        if (data){

            this.id(data.Id);
            this.title(data.Title);
            this.authors(data.Authors);
            this.publishingHouse(data.PublishingHouse);
            this.yearOfPublishing(data.YearOfPublishing);
        }
    }


    HomeModel.getAllBooks();
    ko.applyBindings(HomeModel);
});