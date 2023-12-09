import { useEffect, useState } from "react"
import axios from "axios";
import Product from "./ProductCard"
function Artifacts()
{
var [product, setProd] = useState([]);


    useEffect(() => {
        axios
            .get("http://localhost:8292/api/Product")
            .then(response => {
                console.log(response.data)
                setProd(response.data);
            })
            .catch(error => console.log(error));
    }, [])


    return(
        <div>
            <div className="row">
                <div className="currauc">All Artifacts</div>
            </div>
            <div className="row">
             {product.map((k) => {
            if (k.p_category == "a") {
              return (
                
                  <Product exact imagex={k.p_imgloc} heading={k.p_name} deatils={k.p_descp} productid={k.p_id}></Product>
                
              )
            }
          })}
        </div>
        </div>
    )
}
export default Artifacts