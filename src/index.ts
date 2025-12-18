import express, {type Request, type Response} from "express";

const app = express();
const PORT = 3000;

app.get("/items", (req: Request, res: Response) => {
  res.send(["item1", "item2", "item3"]);
});

app.listen(PORT, () => {
  console.log(`Server running on http://localhost:${PORT}`);
});
