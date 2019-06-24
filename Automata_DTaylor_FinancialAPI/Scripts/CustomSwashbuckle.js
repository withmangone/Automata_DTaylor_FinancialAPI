﻿$(function () {
    $("#logo").text("DT Financial API")
    $("#logo").attr("href", "https://dt-financialapi.azurewebsites.net/")

    $("title").text("DT Financial API")

    $("link[sizes = '32x32']").attr("href", "/Images/GreenLogo.png")
    $("link[sizes = '16x16']").attr("href", "/Images/GreenLogo.png")

    $("a[data-id='BankAccounts']").first().text("Bank Accounts")
    $("a[data-id='BudgetCategory']").first().text("Budget Categories")
    $("a[data-id='BudgetCategoryItems']").first().text("Budget Category Items")

    $("div.input").hide();

    $("td span").text(function() {
        if ($(this).text().toLowerCase() === "double") {
            return "decimal(18,2)";
        }
    });

    $("html")[0].style.visibility = "visible";
});



