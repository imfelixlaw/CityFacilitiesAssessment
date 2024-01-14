import { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';

function App() {
    const [products, setProducts] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        axios.get('https://localhost:7120/Product/')
            .then(response => {
                setProducts(response.data);
            })
            .catch(err => {
                setError(err.message);
                console.error('There was an error!', err);
            });
    }, []);

    return (
         <div>
            {error && <div>Error: {error}</div>}
            {/*//{products && <div>Data: {JSON.stringify(products)}</div>}*/}

            <table border="1">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Description</th>
                    <th>Maximum Quantity</th>
                    <th>Sell Price</th>
                </tr>
            </thead>
            <tbody>
                {products.map(product => (
                    <tr key={product.productId}>
                        <td>{product.name}</td>
                        <td>{product.description}</td>
                        <td>{product.maximumQuantity}</td>
                        <td>{product.sellPrice}</td>
                    </tr>
                ))}
            </tbody>
            </table>
        </div>
    );
}

export default App;