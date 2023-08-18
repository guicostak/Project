import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import '@fortawesome/fontawesome-free/css/all.min.css';
import '../styles/Home.css';
import gif from '../img/Veterinary.gif';
import Swal from 'sweetalert2';
import { useState } from 'react';
import axios from 'axios';

const Home = () => {
    const [cachorrosGrandes, setCachorrosGrandes] = useState("");
    const [cachorrosPequenos, setCachorrosPequenos] = useState("");
    const [data, setData] = useState('');

    const procurarPetshop = async (event) => {
        event.preventDefault();

        if (!cachorrosGrandes || !cachorrosPequenos || !data) {
            Swal.fire(
                'Campos Vazios',
                'Por favor, preencha todos os campos.',
                'warning'
            );
            return;
        } else {
            enviarDados();
        }
    };

    const enviarDados = async () => {
        try {
            const response = await axios.post('http://localhost:5174/procura_petshops', {
                cachorrosGrandes,
                cachorrosPequenos,
                data,
            }, {
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (response.status === 200) {
                const responseData = response.data;

                const nomePetshop = responseData.nomePetshop;
                const valorTotal = responseData.valorTotal;

                Swal.fire(
                    '<h2>Melhor escolha:</h2>',
                    `<strong>Petshop:</strong><p>${nomePetshop}</p><br><strong>Valor total:</strong><p>R$${valorTotal}</p>`,
                    'success'
                );
            } else {
                Swal.fire(
                    'Erro',
                    'Ocorreu um erro ao receber os dados.',
                    'error'
                );
            }
        } catch (error) {
            console.error('Erro:', error);
            Swal.fire(
                'Erro',
                'Ocorreu um erro ao enviar os dados.',
                'error'
            );
        }
    };


    const handleCachorrosGrandesChange = (event) => {
        let inputValue = event.target.value;
        inputValue = inputValue.replace(/\D/g, '');
        setCachorrosGrandes(inputValue);
        
    }

    const handleCachorrosPequenosChange = (event) => {
        let inputValue = event.target.value;
        inputValue = inputValue.replace(/\D/g, '');
        setCachorrosPequenos(inputValue);
    }   


    const handleDataChange = (event) => {
        setData(event.target.value);
    }

    return (
        <div className="container mt-5 d-flex flex-column align-items-center">
            <h1 className="text-center">Escolha o melhor Petshop</h1>
            <div className="d-flex justify-content-center">
                <form className="row g-9 justify-content-center">
                    <div className="col-md-5">
                        <img src={gif} className='veterinario img-fluid' alt="Veterinary GIF" />
                    </div>
                    <div className="col-md-5">
                        <div className="mb-3">
                            <label className="form-label" htmlFor="cachorrosGrandes" title="Cachorros grandes"><i className="fas fa-dog" style={{ marginRight: '1vw'}}></i>Cachorros grandes:</label>
                            <input type="text" maxLength="4" className="form-control" value={cachorrosGrandes} id="cachorrosGrandes" placeholder="Quantidade de cachorros grandes..." onChange={handleCachorrosGrandesChange} />
                        </div>
                        <div className="mb-3">
                            <label className="form-label" htmlFor="cachorrosPequenos"><i className="fas fa-dog" style={{ marginRight: '1vw'}}></i>Cachorros pequenos:</label>
                            <input type="text" maxLength="4" className="form-control" value={cachorrosPequenos} id="cachorrosPequenos" placeholder="Quantidade de cachorros pequenos..." onChange={handleCachorrosPequenosChange} />
                        </div>
                        <div className="mb-3">
                            <label className="form-label" htmlFor="data" title="Data"><i className="fas fa-calendar" style={{ marginRight: '1vw' }}></i>Data:</label>
                            <input type="date" className="form-control" id="data" onChange={handleDataChange} />
                        </div>
                        <button className="btn btn-primary col-md-12 botao" onClick={procurarPetshop}>Buscar</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default Home;
