import express from "express";
import cors from "cors";
import * as dotenv from "dotenv";
import coinRoutes from "./routes/coinsRoutes.js";

import { NotFoundError, errorHandler } from "./middlewares/error-handler.js";
import morgan from "morgan";
import connectDb from "./config/db.js";
const app = express();

dotenv.config();
// badel hedhi ki bech taamel docker-compose up DOCKERSERVERURL
const hostname = process.env.DOCKERSERVERURL;
const port = process.env.SERVERPORT;

//info on req : GET /route ms -25
app.use(morgan("tiny"));

app.use(cors());
connectDb();
//bech taati acces lel dossier media li fih les images, localhost:9095/media/fifa.jpg
app.use("/media", express.static("media"));

app.use(express.json());
app.use(express.urlencoded({ extended: true }));

app.use("/coins", coinRoutes);


app.use(NotFoundError);
app.use(errorHandler);

app.listen(port, hostname, () => {
  console.log(`Server running on ${hostname}:${port}`);
});
