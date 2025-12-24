import express, {type Request, type Response} from "express";
import {ItemsRepository} from "./itemsRepository.js";

const app = express();
const PORT = 3000;

const itemsRepository = new ItemsRepository();

app.get("/", (req: Request, res: Response) => {
  res.status(200).send({});
});

app.get("/items", async (req: Request, res: Response) => {
  res.send(await itemsRepository.getItems());
});

app.post("/items", async (req: Request, res: Response) => {
  const item = await itemsRepository.addItem({
    title: req.body.title,
    body: req.body.body,
  });
  res.send(item);
});

app.listen(PORT, () => {
  console.log(`Server running on http://localhost:${PORT}`);
});
