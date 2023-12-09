--select  (p.p_id),max(b.user_bid_price) as high_bid,(p.base_price) from bid_table as b,products as p where p.p_id=b.p_id and p.p_id=2 group by p.p_id,p.base_price;
execute Bidding @ProdID=4