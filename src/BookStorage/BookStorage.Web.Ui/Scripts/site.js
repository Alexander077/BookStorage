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
                    self.isCreateMode(false);
                    alert("Book successfully added");
                })
            .fail(function (jqXHR, textStatus, errorThrown) {

                if (jqXHR.status === 400){

                    var errData = JSON.parse(jqXHR.responseText);
                    var errText = "";

                    for (var field in errData.ModelState)
                    {
                        errText += errData.ModelState[field][errData.ModelState[field].length - 1] + "\n";
                    }

                    alert("Error while creating book.\n" + errText);
                } else {
                    alert("Error while creating book.  Server side error occurred.");
                }
            })
            .always(function () {
            });
        }

        this.editMode = function (editEnabled) {

            if (editEnabled){
                self.editItem(new BookModel({
                    Id: this.id(),
                    Title: this.title(),
                    Authors : this.authors(),
                    PublishingHouse : this.publishingHouse(),
                    YearOfPublishing : this.yearOfPublishing()
                }));
            } 

            self.isEditMode(editEnabled);
        }

        this.confirmEdit = function () {

            $.ajax({
                method: "PUT",
                url: "/api/books/" + this.editItem().id() ,
                data: {
                    Id: this.editItem().id(),
                    Title: this.editItem().title(),
                    Authors: this.editItem().authors(),
                    PublishingHouse: this.editItem().publishingHouse(),
                    YearOfPublishing: this.editItem().yearOfPublishing()
                }
            })
            .done(function (data, textStatus, jqXHR) {

                var oldObj;

                ko.utils.arrayForEach(self.books(), function(item) {
                    if (item.id() === self.editItem().id()) {
                        oldObj = item;
                    }
                });

                self.books.replace(oldObj, self.editItem());
                alert("Book saved");
                self.isEditMode(false);
            })
            .fail(function (jqXHR, textStatus, errorThrown) {

                if (jqXHR.status === 400)
                {
                    var errData = JSON.parse(jqXHR.responseText);
                    var errText = "";

                    for (var field in errData.ModelState)
                    {
                        errText += errData.ModelState[field][errData.ModelState[field].length - 1] + "\n";
                    }

                    alert("Error while updating book.\n" + errText);
                } else {
                    alert("Error while updating book.  Server side error occurred.");
                }

            }).always(function () {
                
            });
        }

        this.deleteBook = function () {

            if (confirm("Are you sure that you want to delete this book?")) {
                $.ajax({
                        method: "DELETE",
                        url: "/api/books/" + self.editItem().id()
                    })
                    .done(function (data, textStatus, jqXHR) {

                        var delObj;

                        ko.utils.arrayForEach(self.books(), function (item) {
                            if (item.id() === self.editItem().id())
                            {
                                delObj = item;
                            }
                        });

                        self.books.remove(delObj);
                        alert("Book deleted");
                    })
                    .fail(function (jqXHR, textStatus, errorThrown) {
                        alert("Can't delete book. Server side error occurred.");
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
                   if (jqXHR.status === 500){
                       alert("Can't retrieve books list. Server side error occurred.");
                   } else {
                       alert("Error while retrieving books list.");
                   }
               });
        }
    };

    var BookModel = function (data) {

        this.id = ko.observable("");
        this.title = ko.observable("");
        this.authors = ko.observable("");
        this.publishingHouse = ko.observable("");
        this.yearOfPublishing = ko.observable(0);

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