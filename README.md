* GIVEN an item has been added to the basket WHEN placing an order THEN display the correct total for the order
* GIVEN the promo code 'discount10' WHEN placing an order AND the code has not been used before THEN reduce the total by 10%
* GIVEN the promo code 'discount50' WHEN placing an order AND the code has not been used before THEN reduce the total by 50%
* GIVEN a promo code has been used before WHEN placing an order AND attempting to use the same code again THEN warn the user the code is invalid AND do not place the order
