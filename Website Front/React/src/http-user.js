import axios from 'axios';

export default axios.create({
  baseURL: 'http://localhost:7071',
  headers: {
    'Content-Type': 'application/json',
  },
});