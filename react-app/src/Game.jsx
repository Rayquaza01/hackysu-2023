import Container from "@mui/material/Container";
import Grid from "@mui/material/Grid";

export function GamePage(props) {
  //const { unityProvider } = useUnityContext({
  //  loader: "Unity/WebBuild.loader.js",
  //  dataUrl: "Unity/WebBuild.data.gz",
  //  frameworkUrl: "Unity/WebBuild.framework.js.gz",
  //  codeUrl: "Unity/WebBuild.wasm.gz",
  //})

  return (
    <div style={{ textAlign: "center" }}>
      <iframe src={"/static/unity.html"} height="720" width="1280" style={{ marginLeft: "auto", marginRight: "auto"}} />
    </div>
  )
}

document.addEventListener("keydown", (e) => {
  console.log(e.key);
  if (e.key === "Escape") {
    document.blur();
    e.preventDefault();
  }
})
